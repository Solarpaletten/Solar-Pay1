using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class ClientContractsDTO
    {
        public string ContractName { get; set; }
        public string ContractId { get; set; }
        public string ClientName { get; set; }
        public string ContractFullForm { get; set; }
        public string ClientId { get; set; }
        public string Attachment { get; set; }
        public DateTime StartDate {  get; set; }
        public DateTime EndDate {  get; set; }

    }
}
