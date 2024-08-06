using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IAudienceBudgetService
    {
        int AddCompaignBudget(List<AdBudget> adBudgets);
        List<AdBudget> GetAdBudgetByCompaignId(Guid compaignId);

        int DeleteAdCompaignBudget(List<AdBudget> adBudgets);
    }
}
