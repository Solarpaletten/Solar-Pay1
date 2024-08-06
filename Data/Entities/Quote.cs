using Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Quote:BaseEntity
    {
        public decimal UnitPrice {  get; set; }
        public int Packaging { get; set; }
        public string QuoteCurrency { get; set; }
        public decimal ShippingCost {  get; set; }  
        public int ShippingDelivery { get; set; }
        public decimal BankCharges { get; set; }
        public decimal VAT { get; set; }
        public decimal JIC { get; set; } //Just in case
        public decimal Profit {  get; set; }    
        public decimal UnitPriceToClient {  get; set; }
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
        public Guid? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
