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
    public class Client:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public IFormFile doc {  get; set; }
        public string? Attachment { get; set; }
        public string Address { get; set; }
        [NotMapped]
        public DateTime StartDate { get; set; }
        [NotMapped]
        public DateTime EndDate { get; set; }
        [NotMapped]
        public string ContractId { get; set; }
        public ICollection<RFQ>? RFQs { get; set; }
        public ICollection<Client_Contract>? Client_Contracts { get; set; }
    }
}
