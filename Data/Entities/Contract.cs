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
    public class Contract : BaseEntity
    {
        public string Name { get; set; }
        public string Fullform { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [NotMapped]
        public IFormFile doc { get; set; }
        public string? Attachment {  get; set; } 
        public decimal limit {  get; set; }
        public string? Facilities {  get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime InActiveDate { get; set; }
        public ICollection<ContractQuoteRate>? QuoteRates { get; set; }
        public ICollection<ContractLogisticRate>? LogisticRates { get; set; }
        public ICollection<Client_Contract>? Client_Contracts { get; set; }

    }
}
