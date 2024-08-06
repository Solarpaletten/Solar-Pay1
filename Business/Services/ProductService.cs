using Business.IServices;
using Data.Entities;
using DataAccess.Repository;
using DataAccess.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProductService:IProductService
    {
        private readonly IRepository<Product> repository;
        private readonly IUnitofWork unitofWork;
        public ProductService(IRepository<Product> _repository, IUnitofWork _unitofWork)
        {
            repository = _repository;
            unitofWork = _unitofWork;
        }

        public Product AddProduct(Product Product)
        {
            Product result = repository.Add(Product);
            unitofWork.saveChanges();
            return result;
        }

        public Product UpdateProduct(Product Product)
        {
            Product result = repository.Update(Product);
            unitofWork.saveChanges();
            return result;
        }

        public Product GetProductById(Guid id)
        {
            return repository.GetById(id);
        }

        public IQueryable<Product> GetAllProducts()
        {
            IQueryable<Product> Products = repository.GetAll();
            return Products;
        }

        bool IProductService.DeleteProduct(Guid id)
        {
            return repository.Delete(id);
        }
    }
}
