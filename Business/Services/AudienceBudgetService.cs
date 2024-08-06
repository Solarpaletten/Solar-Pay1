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
    public class AudienceBudgetService : IAudienceBudgetService
    {
        private readonly IRepository<AudienceSize> audienceSizesRepository;
        private readonly IRepository<AdBudget> adBudgetRespository;
        private readonly IUnitofWork unitofWork;

        public AudienceBudgetService(IRepository<AudienceSize> _audienceSizesRepository, 
            IRepository<AdBudget> _adBudgetRespository, IUnitofWork _unitofWork)
        {
            audienceSizesRepository = _audienceSizesRepository;
            adBudgetRespository = _adBudgetRespository;
            unitofWork = _unitofWork;
        }
        public int AddCompaignBudget(List<AdBudget> adBudgets)
        {
            this.adBudgetRespository.AddRange(adBudgets);
            return this.unitofWork.saveChanges();
        }

        public int DeleteAdCompaignBudget(List<AdBudget> adBudgets)
        {
            this.adBudgetRespository.Delete(adBudgets);
            return this.unitofWork.saveChanges();
        }

        public List<AdBudget> GetAdBudgetByCompaignId(Guid compaignId)
		{
            return this.adBudgetRespository.GetDataFiltered(x => x.AdCompaignId == compaignId);
		}
	}
}
