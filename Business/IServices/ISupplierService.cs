using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface ISupplierService
    {
        Supplier AddSupplier(Supplier Supplier);
        Supplier UpdateSupplier(Supplier Supplier);
        Supplier GetSupplierById(Guid id);
        bool DeleteSupplier(Guid id);
        IQueryable<Supplier> GetAllSuppliers();
    }
}
