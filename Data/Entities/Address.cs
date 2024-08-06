using Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Address:BaseEntity
    {
        public string Location{ get; set; } 
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Employee { get; set; }
        public bool Registration { get; set; } = false;
        public bool Correspondence { get; set; } = false;
        public bool Loading { get; set; } = false;
        public bool Unloading { get; set; } = false;
        public bool Divid { get; set; } = false;
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
