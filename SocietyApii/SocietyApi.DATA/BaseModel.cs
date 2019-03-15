using System;
using System.ComponentModel.DataAnnotations;

namespace SocietyApi.DATA
{
    public class BaseModel
    {
        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public string CreatedDate { get; set; }

        [Required]
        public string UpdatedDate { get; set; }
    }
}
