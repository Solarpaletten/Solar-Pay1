using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface ICustomerService
    {
        Customer AddCustomer(Customer Customer);
        Customer UpdateCustomer(Customer Customer);
        Customer GetCustomerById(Guid id);
        bool DeleteCustomer(Guid id);
        IQueryable<Customer> GetAllCustomers();
    }
}
