using Data.Entities.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Customer : BaseEntity
    {
        public string Title { get; set; }
        public string Abbreviation { get; set; }
        public bool IsActive { get; set; } = false;
        public bool Juridical { get; set; } = false;
        public bool debt { get; set; } = false;
        public string Foreigner { get; set; }
        public string Code { get; set; }
        public string ActivityNumber { get; set; }
        public string VATCode { get; set; }
        public string Website { get; set; }
        public string Tel { get; set; }
        public string PostOffice { get; set; }
        public string ContactInfo { get; set; }
        public string Notes { get; set; }
        public string PayThrough { get; set; }
        public string EORI { get; set; }
        public string Fax { get; set; }
        public string Foreign { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateOfRegistration { get; set; } = DateTime.Now;
        public decimal VATrate { get; set; } = decimal.Zero;
        public decimal CreditAmount { get; set; } = decimal.Zero;
        public ICollection<Bank>? Banks { get; set; }
        public ICollection<Address>? Addresses { get; set; }
    }
}
