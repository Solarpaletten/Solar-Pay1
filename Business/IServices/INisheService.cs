using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
	public interface INisheService
	{
		IQueryable<Nishes> GetAllNishes();
		List<UserNishes> GetAllNishesByUserId(string userId);
        int AddUserNishes(List<UserNishes> userNishes);
        List<AdNishes> GetAllNishesByAdCompaignId(Guid adCompaignId);
        int AddAdCompaignNishes(List<AdNishes> adNishes);
        int DeleteAdCompaignNishes(List<AdNishes> adNishes);
        int DeleteUserNishes(List<UserNishes> userNishes);
    }
}
