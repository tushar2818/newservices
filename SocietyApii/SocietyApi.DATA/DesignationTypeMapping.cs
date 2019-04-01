using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("DesignationTypeMapping")]
    public class DesignationTypeMapping 
    {
        [Key]
        public Int64 DesignationTypeMappingID { get; set; }

        [Required]
        [ForeignKey("DesignationMaster")]
        public Int64 DesignationMasterID { get; set; }
        public DesignationMaster DesignationMaster { get; set; }

        [Required]
        [ForeignKey("DesignationType")]
        public Int64 DesignationTypeID { get; set; }
        public DesignationType DesignationType { get; set; }

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
