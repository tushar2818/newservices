using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
//https://github.com/aspnet/Identity/issues/351
namespace IdentityService.DATA
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PasswordHash2 { get; set; }


        [ForeignKey("CreatedUser")]
        public string CreatedBy { get; set; }
        [ForeignKey("UpdatedUser")]
        public string UpdatedBy { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public string CreatedDate { get; set; }
        [Required]
        public string UpdatedDate { get; set; }

        public ApplicationUser CreatedUser { get; set; }
        public ApplicationUser UpdatedUser { get; set; }

    }
}
