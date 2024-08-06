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
    public class RFQService:IRFQService
    {
        private readonly IRepository<RFQ> repository;
        private readonly IUnitofWork unitofWork;
        public RFQService(IRepository<RFQ> _repository, IUnitofWork _unitofWork)
        {
            repository = _repository;
            unitofWork = _unitofWork;
        }

        public RFQ AddRFQ(RFQ RFQ)
        {
            RFQ result = repository.Add(RFQ);
            unitofWork.saveChanges();
            return result;
        }

        public RFQ UpdateRFQ(RFQ RFQ)
        {
            RFQ result = repository.Update(RFQ);
            unitofWork.saveChanges();
            return result;
        }

        public RFQ GetRFQById(Guid id)
        {
            return repository.GetById(id);
        }

        public IQueryable<RFQ> GetAllRFQs()
        {
            IQueryable<RFQ> RFQs = repository.GetAll();
            return RFQs;
        }

        bool IRFQService.DeleteRFQ(Guid id)
        {
            return repository.Delete(id);
        }
    }
}
