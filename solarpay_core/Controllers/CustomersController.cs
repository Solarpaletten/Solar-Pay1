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
using Business.Services;
using solarpay_core.Helper;

namespace solarpay_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerBankService _customerBankService;
        private readonly ICustomerAddressService _customerAddressService;

        public CustomersController(ICustomerService customerService, ICustomerBankService customerBankService,ICustomerAddressService customerAddressService)
        {
            _customerService= customerService;
            _customerBankService= customerBankService;
            _customerAddressService= customerAddressService;
        }

        // GET: api/Customers
        [HttpGet("getcustomers")]
        public async Task<ResponseModel<List<Customer>>> GetCustomers()
        {
            ResponseModel<List<Customer>> response = new ResponseModel<List<Customer>>();
            try
            {
                response.status = true;
                response.Message = "Customers list.";
                response.Data = _customerService.GetAllCustomers().ToList();
                return response;
            }
            catch (Exception)
            {
                response.status = false;
                response.Message = "There is an error while fetching customer's data.";
                return response;
            }
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ResponseModel<Customer>> GetCustomer(string id)
        {
            ResponseModel<Customer> response = new ResponseModel<Customer>();
            try
            {
                var customer = _customerService.GetCustomerById(Guid.Parse(id));
                customer.Banks=_customerBankService.GetAllBanks().Where(x=>x.CustomerId== Guid.Parse(id)).ToList();
                customer.Addresses=_customerAddressService.GetAllAddresss().Where(x=>x.CustomerId == Guid.Parse(id)).ToList();
                response.status = true;
                response.Message = "Customer details.";
                response.Data = customer;
                return response;
            }
            catch (Exception)
            {
                response.status = false;
                response.Message = "There is an error while fetching customer's details.";
                return response;
            }
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateCustomer")]
        public async Task<ResponseModel<Customer>> PutCustomer([FromBody]Customer customer)
        {
            ResponseModel<Customer> response = new ResponseModel<Customer>();
            try
            {
                response.status = true;
                response.Message = "Customer has been updated successfully.";
                response.Data = _customerService.UpdateCustomer(customer);
                return response;
            }
            catch (Exception e)
            {
                response.status = false;
                response.Message = e.Message;
                return response;
            }
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddCustomer")]
        public async Task<ResponseModel<Customer>> PostCustomer(Customer customer)
        {
            ResponseModel<Customer> response = new ResponseModel<Customer>();
            try
            {
                if (customer.Id!=null)
                {
                    response.status = true;
                    response.Message = "Customer has been updated successfully.";
                    response.Data = _customerService.UpdateCustomer(customer);
                    return response;
                }
                response.status = true;
                response.Message = "Customer has been created successfully.";
                response.Data = _customerService.AddCustomer(customer);
                return response;
            }
            catch (Exception e)
            {
                response.status = false;
                response.Message = e.Message;
                return response;
            }
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ResponseModel<bool>> DeleteCustomer(string id)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();
            try
            {
                response.status = true;
                response.Message = "Customer has been deleted successfully.";
                response.Data = _customerService.DeleteCustomer(Guid.Parse(id));
                return response;
            }
            catch (Exception e)
            {
                response.status = false;
                response.Message = e.Message;
                return response;
            }
        }

        private bool CustomerExists(Guid id)
        {
            return _customerService.GetCustomerById(id) != null;
        }
    }
}
