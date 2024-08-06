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
	public class NisheService : INisheService
	{
		private readonly IRepository<Nishes> repository;
        private readonly IRepository<UserNishes> userNishesRepository;
        private readonly IRepository<AdNishes> adNishesRepository;
        private readonly IUnitofWork unitofWork;

        public NisheService(IRepository<Nishes> _repository, IRepository<UserNishes> _userNishesRepository, 
            IRepository<AdNishes> _adNishesRepository, IUnitofWork _unitofWork)
        {
			repository = _repository;
            userNishesRepository = _userNishesRepository;
            adNishesRepository = _adNishesRepository;
            unitofWork = _unitofWork;
		}

        public int AddAdCompaignNishes(List<AdNishes> adNishes)
        {
            this.adNishesRepository.AddRange(adNishes);
            return this.unitofWork.saveChanges();
        }

        public int AddUserNishes(List<UserNishes> userNishes)
        {
			this.userNishesRepository.AddRange(userNishes);
            return unitofWork.saveChanges();
        }

        public int DeleteAdCompaignNishes(List<AdNishes> adNishes)
        {
            this.adNishesRepository.Delete(adNishes);
            return this.unitofWork.saveChanges();
        }

        public IQueryable<Nishes> GetAllNishes()
		{
			return this.repository.GetAll();
		}

        public List<AdNishes> GetAllNishesByAdCompaignId(Guid adCompaignId)
        {
            return this.adNishesRepository.GetDataFiltered(x => x.AdCompaignId == adCompaignId);
        }

        public List<UserNishes> GetAllNishesByUserId(string userId)
		{
            return this.userNishesRepository.GetDataFiltered(x => x.UserId == userId);
		}

        public int DeleteUserNishes(List<UserNishes> userNishes)
        {
            this.userNishesRepository.Delete(userNishes);
            return this.unitofWork.saveChanges();
        }
    }
}
