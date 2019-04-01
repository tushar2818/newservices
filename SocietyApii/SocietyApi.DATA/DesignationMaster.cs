using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("DesignationMaster")]
    public class DesignationMaster 
    {
        [Key]
        public Int64 DesignationMasterID { get; set; }

        [Required]
        public string DesignationKey { get; set; }

        [Required]
        public string DesignationValue { get; set; }

        public string DesignationHin { get; set; }

        public string DesignationMar { get; set; }

        public string DesignationDetails { get; set; }

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
