using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IRFQService
    {
        RFQ AddRFQ(RFQ RFQ);
        RFQ UpdateRFQ(RFQ RFQ);
        RFQ GetRFQById(Guid id);
        bool DeleteRFQ(Guid id);
        IQueryable<RFQ> GetAllRFQs();
    }
}
