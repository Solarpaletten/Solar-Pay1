using Data.Entities;
using Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface ICustomerAddressService
    {
        Address AddAddress(Address Address);
        Address UpdateAddress(Address Address);
        Address GetAddressById(Guid id);
        bool DeleteAddress(Guid id);
        IQueryable<Address> GetAllAddresss();
    }
}
