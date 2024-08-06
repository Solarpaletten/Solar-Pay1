using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using Data.Entities;
using Business.IServices;
using solarpay_core.Helper;

namespace solarpay_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressesController : ControllerBase
    {
        private readonly ICustomerAddressService _customerAddressService;

        public CustomerAddressesController(ICustomerAddressService customerAddressService)
        {
            _customerAddressService= customerAddressService;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ResponseModel<List<Address>>> GetCustomerAddresses()
        {
            ResponseModel<List<Address>> response = new ResponseModel<List<Address>>();
            try
            {
                response.status = true;
                response.Message = "Customer addresses list.";
                response.Data = _customerAddressService.GetAllAddresss().ToList();
                return response;
            }
            catch (Exception)
            {
                response.status = false;
                response.Message = "There is an error while fetching customer's addresses.";
                return response;
            }
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ResponseModel<Address>> GetAddress(string id)
        {
            ResponseModel<Address> response = new ResponseModel<Address>();
            try
            {
                response.status = true;
                response.Message = "Customer address details.";
                response.Data = _customerAddressService.GetAddressById(Guid.Parse(id));
                return response;
            }
            catch (Exception)
            {
                response.status = false;
                response.Message = "There is an error while fetching customer's address details.";
                return response;
            }
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ResponseModel<Address>> PutAddress([FromBody]Address address)
        {
            ResponseModel<Address> response = new ResponseModel<Address>();
            try
            {
                response.status = true;
                response.Message = "Customer address has been updated successfully.";
                response.Data = _customerAddressService.UpdateAddress(address);
                return response;
            }
            catch (Exception e)
            {
                response.status = false;
                response.Message = e.Message;
                return response;
            }
        }

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ResponseModel<Address>> PostAddress(Address address)
        {
            ResponseModel<Address> response = new ResponseModel<Address>();
            try
            {
                response.status = true;
                response.Message = "Customer address has been created successfully.";
                response.Data = _customerAddressService.AddAddress(address);
                return response;
            }
            catch (Exception e)
            {
                response.status = false;
                response.Message = e.Message;
                return response;
            }
        }

            // DELETE: api/Addresses/5
            [HttpDelete("{id}")]
        public async Task<ResponseModel<bool>> DeleteAddress(string id)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();
            try
            {
                response.status = true;
                response.Message = "Customer address has been deleted successfully.";
                response.Data = _customerAddressService.DeleteAddress(Guid.Parse(id));
                return response;
            }
            catch (Exception e)
            {
                response.status = false;
                response.Message = e.Message;
                return response;
            }
        }

        private bool AddressExists(Guid id)
        {
            return _customerAddressService.GetAddressById(id) != null;
        }
    }
}
