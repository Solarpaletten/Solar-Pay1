using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
	public class DataContext : IdentityDbContext<ApplicationUser>
	{
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bank> CustomerBanks { get; set; }
        public DbSet<Address> CustomerAddresses { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string ADMIN_ID = "9eb72a27-b7c1-4b15-8267-9b0d43b945c5";
            string ROLE_ID = "a8d81fff-4580-4e4f-8c34-281b272da9fb";

            builder.Entity<IdentityRole>().HasData(
               new IdentityRole() { Id = ROLE_ID, Name = "Admin", NormalizedName = "Admin", ConcurrencyStamp = "1" },
               new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Manager", NormalizedName = "Manager", ConcurrencyStamp = "2" },
               new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Accountant", NormalizedName = "Accountant", ConcurrencyStamp = "3" },
               new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Client", NormalizedName = "Client", ConcurrencyStamp = "4" }
           );

            //create admin user
            var user = new ApplicationUser
            {
                Id = ADMIN_ID,
                FirstName = "Super",
                LastName = "Admin",
                UserName = "SuperAdmin",
                NormalizedUserName = "SuperAdmin",
                Email = "admin@solarpay.com",
                NormalizedEmail = "admin@solarpay.com",
                PhoneNumber = "+49 163 9480534",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                LockoutEnabled = true,
                IsApproved = true
            };

            //set user password
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = ph.HashPassword(user, "Admin@123");

            builder.Entity<ApplicationUser>().HasData(user);

            // seed admin user role
            builder.Entity<IdentityUserRole<string>>().HasData(
           new IdentityUserRole<string>
           {
               RoleId = ROLE_ID,
               UserId = ADMIN_ID,
           }
           );

            builder.Entity<IdentityUserClaim<string>>().HasData(
           new IdentityUserClaim<string>
           {
               Id = 4,
               UserId = ADMIN_ID,
               ClaimValue = "admin",
               ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
           }
           );

        }
    }
}
