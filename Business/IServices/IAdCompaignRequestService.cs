using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IAdCompaignRequestService
    {
        int AddRequest(AdCompaignRequest request);
        int UpdateRequest(AdCompaignRequest request);
        int DeleteRequest(Guid Id);
    }
}
