using Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ContractLogisticRate:BaseEntity
    {
        public decimal RangeFrom { get; set; }
        public decimal RangeTo { get; set; }
        public decimal LogisticCharges { get; set; }
        public string Description {  get; set; }    
        public Guid? ContractId { get; set; }
        public Contract Contract { get; set; }
    }
}
