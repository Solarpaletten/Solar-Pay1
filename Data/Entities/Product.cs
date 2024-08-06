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
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        [NotMapped]
        public IFormFile doc { get; set; } 
        public string? ImageUrl { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Reference { get; set; }
        public Guid? RFQId { get; set; }
        public RFQ? RFQ { get; set; }
        public Guid? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public ICollection<Quote>? Quotes { get; set; }
    }
}
