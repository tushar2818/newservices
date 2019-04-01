using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("DesignationType")]
    public class DesignationType 
    {
        [Key]
        public Int64 DesignationTypeID { get; set; }

        [Required]
        public string DesignationTypeKey { get; set; }

        [Required]
        public string DesignationTypeValue { get; set; }

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
