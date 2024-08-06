using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IResolutionService
    {
        int AddResolution(AdResolution adResolution);
        int UpdateResolution(AdResolution adResolution);
        int DeleteResolution(Guid Id);
        List<AdResolution> GetResolutions(Guid adCompaignId);
    }
}
