using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("BuildingMaster")]
    public class BuildingMaster 
    {
        [Key]
        public Int64 BuildingMasterID { get; set; }

        [Required]
        [ForeignKey("ProjectMaster")]
        public Int64 ProjectMasterID { get; set; }
        public ProjectMaster ProjectMaster { get; set; }

        [Required]
        public string BuildingName { get; set; }

        public string BuildingDetails { get; set; }

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
