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
    public class Supplier:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {  get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        public decimal CreditLimit { get; set; }
        public string PaymentMethod { get; set; }
        public string Website { get; set; }
        public string TaxationNo { get; set; }
        [NotMapped]
        public IFormFile doc { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
