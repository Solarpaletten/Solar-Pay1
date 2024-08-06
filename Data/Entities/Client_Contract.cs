using Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Client_Contract:BaseEntity
    {
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public string Attachment { get; set; }
        public Guid ClientId { get; set; }
        public Guid ContractId { get; set; }
        public string? ContractType { get; set; }
        public Client Client{ get; set; }
        public Contract Contract{ get; set; }
    }
}
