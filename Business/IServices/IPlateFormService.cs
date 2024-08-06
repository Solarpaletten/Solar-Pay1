using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
	public interface IPlateFormService
	{
		IQueryable<SocialPlateForm> GetAllPlateForms();

		int AddUserPlateForms(List<UserPlateForm> userPlateForms);

		IQueryable<AudienceSize> GetAllAudienceSizes();

		List<UserPlateForm> GetAllPlateFormsByUserId(string userId);

		int DeleteUserSocialPlateForms(List<UserPlateForm> userPlateForms);
	}
}
