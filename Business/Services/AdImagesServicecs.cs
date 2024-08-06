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
    public class AdImagesService : IAdImagesService
    {
        private readonly IRepository<AdImages> adImagesRespository;
        private readonly IUnitofWork unitofWork;

        public AdImagesService(IRepository<AdImages> _adImagesRespository, IUnitofWork _unitofWork)
        {
            adImagesRespository = _adImagesRespository;
            unitofWork = _unitofWork;
        }
        public int AddCompaignImages(List<AdImages> adImages)
        {
            this.adImagesRespository.AddRange(adImages);
            return this.unitofWork.saveChanges();
        }

        public int DeleteCompaignImages(List<AdImages> adImages)
        {
            this.adImagesRespository.Delete(adImages);
            return this.unitofWork.saveChanges();
        }

        public List<AdImages> GetAllImagesByAdCompaignId(Guid adCompaignId)
        {
            return this.adImagesRespository.GetDataFiltered(x => x.AdCompaignId == adCompaignId);
        }
    }
}
