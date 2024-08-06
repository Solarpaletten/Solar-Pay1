using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using solarpay_core.Helper;
using solarpay_core.Models;
using solarpay_core.Helper;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace rfid_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> singinmanager, RoleManager<IdentityRole> roleManager, IConfiguration config)
        {
            _config = config;
            _userManager = userManager;
            _signInManager = singinmanager;
            _roleManager = roleManager;
        }
        [HttpPost("register")]
        public async Task<ResponseModel<ApplicationUser>> Register(RegisterVM user)
        {
            var response = new ResponseModel<ApplicationUser>();
            try
            {
                ApplicationUser newUser = new ApplicationUser()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.Phone,
                    UserName=user.Email
                };
                var result = await _userManager.CreateAsync(newUser, user.Password);
                if (!result.Succeeded)
                {
                    List<string> errors=result.Errors.Select(x=>x.Description).ToList();
                    response.status = false;
                    response.Message = String.Join("\n", errors);
                    response.Data = null;
                    return response;
                }
                else
                { 
                    if (!string.IsNullOrEmpty(user.RoleId))
                    {
                        await _userManager.AddToRoleAsync(newUser, "Admin");
                    }
                    response.status = true;
                    response.Message = "User has been registered successfully.";
                    newUser.jwt = GenerateJWTToken(newUser);
                    response.Data = newUser;
                    return response;
                }
            }
            catch (Exception e)
            {
                response.status = false;
                response.Message = e.Message;
                response.Data = null;
                return response;
            }
        }

        [HttpPost("Login")]
        public async Task<ResponseModel<ApplicationUser>> Login(LoginVM login)
        {
            var response = new ResponseModel<ApplicationUser>();
            try
            {
                var user = await _userManager.FindByEmailAsync(login.Email);
                if (user == null)
                {
                    response.status = false;
                    response.Data = null;
                    response.Message = "User not found with this email address.";
                    return response;
                }
                else
                {
                    if (!user.IsApproved)
                    {
                        response.status = false;
                        response.Data = null;
                        response.Message = "User is not approved by administrator.";
                        return response;
                    }
                    var result = await _userManager.CheckPasswordAsync(user, login.Password);
                    if (!result)
                    {
                        response.status = false;
                        response.Data = null;
                        response.Message = "Invalid email or password.";
                        return response;
                    }
                    else
                    {
                        user.jwt = GenerateJWTToken(user);
                        response.status = true;
                        response.Data = user;
                        response.Message = "Logged in successfully.";
                        return response;
                    }
                }
            }
            catch (Exception e)
            {
                response.status = false;
                response.Data = null;
                response.Message = e.Message;
                return response;
            }
        }
        [HttpGet("Logout")]
        public async Task<ResponseModel<string>> Logout()
        {
            ResponseModel<string> response = null;
            try
            {
                await _signInManager.SignOutAsync();
                return response = new ResponseModel<string> { status = true, Message = "Loged out successfully.", Data = "" };
            }
            catch (Exception e)
            {
                return response = new ResponseModel<string> { status = false, Message = e.Message };
            }
        }
        private string GenerateJWTToken(ApplicationUser user)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("Jwt").GetSection("key").Value!);
            var roles = _userManager.GetRolesAsync(user).Result;
            List<Claim> claims = [
                new (JwtRegisteredClaimNames.Email,user.Email??""),
                new (JwtRegisteredClaimNames.Name,user.FirstName+" "+user.LastName??""),
                new (JwtRegisteredClaimNames.NameId,user.Id??""),
                new (JwtRegisteredClaimNames.Aud,_config.GetSection("Jwt").GetSection("audience").Value!??""),
                new (JwtRegisteredClaimNames.Iss,_config.GetSection("Jwt").GetSection("issuer").Value!??""),
                ];
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(Convert.ToInt16(_config.GetSection("Jwt").GetSection("expiryDuration").Value ?? "1")),
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256

                )
            };
            var token = tokenhandler.CreateToken(tokenDescription);
            return tokenhandler.WriteToken(token);
        }
        [HttpGet("Roles")]
        public async Task<ResponseModel<List<IdentityRole>>> GetAllRoles()
        {
            var response = new ResponseModel<List<IdentityRole>>();
            try
            {
                List<IdentityRole> roles = await _roleManager.Roles.ToListAsync();
                response.status = true;
                response.Data = roles;
                response.Message = "Success!";
            }
            catch (Exception e)
            {
                response.status = false;
                response.Data = new List<IdentityRole>();
                response.Message = e.Message;
            }
            return response;
        }
    }
}
