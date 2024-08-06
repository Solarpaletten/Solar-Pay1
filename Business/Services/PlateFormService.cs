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
	public class PlateFormService : IPlateFormService
	{
		private readonly IRepository<SocialPlateForm> repository;
		private readonly IRepository<UserPlateForm> userPlateFormRespositry;
		private readonly IRepository<AudienceSize> audienceSizes;
		private readonly IUnitofWork unitofWork;
		public PlateFormService(IRepository<SocialPlateForm> _repository, IRepository<UserPlateForm> _userPlateFormRespositry,
			IRepository<AudienceSize> _audienceSizes, IUnitofWork _unitofWork)
        {
			repository = _repository;
			userPlateFormRespositry = _userPlateFormRespositry;
			audienceSizes = _audienceSizes;
			unitofWork = _unitofWork;
		}

		public int AddUserPlateForm(UserPlateForm userPlateForms)
		{
			this.userPlateFormRespositry.Add(userPlateForms);
			return unitofWork.saveChanges();
		}

		public int AddUserPlateForms(List<UserPlateForm> userPlateForms)
		{
			this.userPlateFormRespositry.AddRange(userPlateForms);
			return unitofWork.saveChanges();
		}

        public int DeleteUserSocialPlateForms(List<UserPlateForm> userPlateForms)
        {
            this.userPlateFormRespositry.Delete(userPlateForms);
            return unitofWork.saveChanges();
        }

        public IQueryable<AudienceSize> GetAllAudienceSizes()
		{
			return this.audienceSizes.GetAll();
		}

		public IQueryable<SocialPlateForm> GetAllPlateForms()
		{
			return this.repository.GetAll();
		}

		public List<UserPlateForm> GetAllPlateFormsByUserId(string userId)
		{
			return this.userPlateFormRespositry.GetDataFiltered(x => x.UserId == userId);
		}
	}
}
