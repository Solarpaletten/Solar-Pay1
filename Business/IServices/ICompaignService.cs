using Data.Entities;
using Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface ICompaignService
    {
        AdCompaign AddCompaign(AdCompaign compaign);
        int UpdateCompaign(AdCompaign compaign);
        AdCompaign GetCompaignById(Guid id);
        int DeleteCompaign(Guid id);
        List<AdCompaign> GetAllCompaigns();

        List<Country> GetCountries();

        int PlaceAdCompaignBid(AdCompaignBid adCompaignBid);
		AdCompaignBid GetAdCompaignBid(Guid Id);
		List<AdCompaignBid> GetAllCampaignBidsByInfluencerId(string influencerId);
		int UpdateAdCompaignBid(AdCompaignBid adCompaignBid);
	}
}
