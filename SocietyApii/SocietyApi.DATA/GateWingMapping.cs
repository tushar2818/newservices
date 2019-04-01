using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("GateWingMapping")]
    public class GateWingMapping 
    {
        [Key]
        public Int64 GateWingMappingID { get; set; }

        [Required]
        [ForeignKey("GateMaster")]
        public Int64 GateMasterID { get; set; }
        public GateMaster GateMaster { get; set; }

        [Required]
        [ForeignKey("WingMaster")]
        public Int64 WingMasterID { get; set; }
        public WingMaster WingMaster { get; set; }

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
