using Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ExchangeRate:BaseEntity
    {
        public string Currency { get; set; }
        public decimal ActualExchange { get; set; }
        public decimal Additional { get; set; }
        public decimal TotalExchange { get; set; }
        public Guid? RFQId { get; set; }
        public RFQ? RFQ { get; set; }
    }
}
