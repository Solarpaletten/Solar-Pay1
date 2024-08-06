using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsApproved { get; set; }=false;
        [NotMapped]
        public string? jwt {  get; set; }
        [NotMapped]
        public string? rolename { get; set; }
        //public virtual ICollection<RFQ>? RFQs { get; set; }
    }
}
