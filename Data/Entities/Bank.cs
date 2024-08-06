using Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Bank:BaseEntity
    {
        public string AccountNo { get; set; }
        public string BankName { get; set; }
        public string BankCode { get; set; }
        public string SwiftCode { get; set; }
        public bool IsMain { get; set; } = false;
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
