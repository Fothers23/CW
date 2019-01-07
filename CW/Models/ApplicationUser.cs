using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace CW.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Home Town")]
        public string HomeTown { get; set; }

        [StringLength(50)]
        public string Job { get; set; }
    }
}
