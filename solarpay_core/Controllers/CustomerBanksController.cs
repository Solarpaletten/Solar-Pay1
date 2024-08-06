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
    public class CustomerBanksController : ControllerBase
    {
        private readonly ICustomerBankService _customerBankService;

        public CustomerBanksController(ICustomerBankService customerBankService)
        {
            _customerBankService=customerBankService;
        }

        // GET: api/Banks
        [HttpGet]
        public async Task<ResponseModel<List<Bank>>> GetCustomerBanks()
        {
            ResponseModel<List<Bank>> response = new ResponseModel<List<Bank>>();
            try
            {
                response.status = true;
                response.Message = "Customer's bank list.";
                response.Data = _customerBankService.GetAllBanks().ToList();
                return response;
            }
            catch (Exception)
            {
                response.status = false;
                response.Message = "There is an error while fetching customer's bank data.";
                return response;
            }
        }

        // GET: api/Banks/5
        [HttpGet("{id}")]
        public async Task<ResponseModel<Bank>> GetBank(string id)
        {
            ResponseModel<Bank> response = new ResponseModel<Bank>();
            try
            {
                response.status = true;
                response.Message = "Customer bank details.";
                response.Data = _customerBankService.GetBankById(Guid.Parse(id));
                return response;
            }
            catch (Exception)
            {
                response.status = false;
                response.Message = "There is an error while fetching customer's bank details.";
                return response;
            }
        }

        // PUT: api/Banks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ResponseModel<Bank>> PutBank([FromBody]Bank bank)
        {
            ResponseModel<Bank> response = new ResponseModel<Bank>();
            try
            {
                response.status = true;
                response.Message = "Customer bank has been updated successfully.";
                response.Data = _customerBankService.UpdateBank(bank);
                return response;
            }
            catch (Exception e)
            {
                response.status = false;
                response.Message = e.Message;
                return response;
            }
        }

        // POST: api/Banks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ResponseModel<Bank>> PostBank(Bank bank)
        {
            ResponseModel<Bank> response = new ResponseModel<Bank>();
            try
            {
                response.status = true;
                response.Message = "Customer bank has been created successfully.";
                response.Data = _customerBankService.AddBank(bank);
                return response;
            }
            catch (Exception e)
            {
                response.status = false;
                response.Message = e.Message;
                return response;
            }
        }

        // DELETE: api/Banks/5
        [HttpDelete("{id}")]
        public async Task<ResponseModel<bool>> DeleteBank(string id)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();
            try
            {
                response.status = true;
                response.Message = "Customer bank has been deleted successfully.";
                response.Data = _customerBankService.DeleteBank(Guid.Parse(id));
                return response;
            }
            catch (Exception e)
            {
                response.status = false;
                response.Message = e.Message;
                return response;
            }
        }

        private bool BankExists(Guid id)
        {
            return _customerBankService.GetBankById(id) != null;
        }
    }
}
