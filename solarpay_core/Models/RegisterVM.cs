using System.ComponentModel.DataAnnotations;

namespace solarpay_core.Models
{
    public class RegisterVM
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone{ get; set; }
        [Required]
        public string RoleId {  get; set; }
    }
}
