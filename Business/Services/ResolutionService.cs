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
    public class ResolutionService : IResolutionService
    {
        private readonly IRepository<AdResolution> repository;
        private readonly IUnitofWork unitofWork;

        public ResolutionService(IRepository<AdResolution> _repository, IUnitofWork _unitofWork)
        {
            repository = _repository;
            unitofWork = _unitofWork;
        }
        public int AddResolution(AdResolution adResolution)
        {
           this.repository.Add(adResolution);
            return this.unitofWork.saveChanges();
        }

        public int DeleteResolution(Guid Id)
        {
            this.repository.Delete(Id);
            return this.unitofWork.saveChanges();
        }

        public List<AdResolution> GetResolutions(Guid adCompaignId)
        {
            return this.repository.GetAll().Where(x => x.AdCompaignId == adCompaignId).OrderByDescending(x => x.CreatedDate).ToList();
        }

        public int UpdateResolution(AdResolution adResolution)
        {
            this.repository.Update(adResolution);
            return this.unitofWork.saveChanges();
        }
    }
}
