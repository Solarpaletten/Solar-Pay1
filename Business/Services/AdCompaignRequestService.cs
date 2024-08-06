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
    public class AdCompaignRequestService : IAdCompaignRequestService
    {
        private readonly IRepository<AdCompaignRequest> repository;
        private readonly IUnitofWork unitofWork;

        public AdCompaignRequestService(IRepository<AdCompaignRequest> _repository, IUnitofWork _unitofWork)
        {
            repository = _repository;
            unitofWork = _unitofWork;
        }
        public int AddRequest(AdCompaignRequest request)
        {
            this.repository.Add(request);
            return this.unitofWork.saveChanges();
        }

        public int DeleteRequest(Guid Id)
        {
            this.repository.Delete(Id);
            return this.unitofWork.saveChanges();
        }

        public int UpdateRequest(AdCompaignRequest request)
        {
            this.repository.Update(request);
            return this.unitofWork.saveChanges();
        }
    }
}
