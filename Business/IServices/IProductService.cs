using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IProductService
    {
        Product AddProduct(Product Product);
        Product UpdateProduct(Product Product);
        Product GetProductById(Guid id);
        bool DeleteProduct(Guid id);
        IQueryable<Product> GetAllProducts();
    }
}
