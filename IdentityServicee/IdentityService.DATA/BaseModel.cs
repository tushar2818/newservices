using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityService.DATA
{
    public class BaseModel
    {
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public Int64 CreatedDate { get; set; }
        [Required]
        public Int64 UpdatedDate { get; set; }
    }
}
