using Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class RFQ:BaseEntity
    {
        public string? RFQNumber {  get; set; }
        public int Periority {  get; set; }
        public string RequestorName {  get; set; }
        public string RequestorEmail { get; set; }
        public string RequestorPhone { get; set; }
        public string? ClientId { get; set; }
        public string? ContractId { get; set; }
        public DateTime SLA { get; set; }
        public string Title { get; set; }
        public string docNo { get; set; }
        public Client? Client { get; set; }
        public Contract? Contract { get; set; }
        public ICollection<ExchangeRate>? ExchangeRates { get; set; }
        public Guid? UserId { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
