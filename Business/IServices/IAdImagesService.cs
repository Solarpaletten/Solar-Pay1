using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IAdImagesService
    {
        int AddCompaignImages(List<AdImages> adImages);

        List<AdImages> GetAllImagesByAdCompaignId(Guid adCompaignId);
        int DeleteCompaignImages(List<AdImages> adImages);
    }
}
