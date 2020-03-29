using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Data
{
    public class ApplicationUser : IdentityUser
    {
        public int Points { get; set; }
        public int BPostalCode { get; set; }
        public string BCity { get; set; }
        public string BStreetName { get; set; }
        [Required]
        public int DPostalCode { get; set; }
        [Required]
        public string DCity { get; set; }
        [Required]
        public string DStreetName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public override string PhoneNumber { get; set; }
    }
}
