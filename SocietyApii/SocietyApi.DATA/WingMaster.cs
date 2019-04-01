using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("WingMaster")]
    public class WingMaster 
    {
        [Key]
        public Int64 WingMasterID { get; set; }

        [Required]
        [ForeignKey("BuildingMaster")]
        public Int64 BuildingMasterID { get; set; }
        public BuildingMaster BuildingMaster { get; set; }

        [Required]
        public string WingName { get; set; }

        [Required]
        public Int64 NoOfFloor { get; set; }

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
