using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("FlatMaster")]
    public class FlatMaster 
    {
        [Key]
        public Int64 FlatMasterID { get; set; }

        [Required]
        [ForeignKey("WingMaster")]
        public Int64 WingMasterID { get; set; }
        public WingMaster WingMaster { get; set; }

        [Required]
        [ForeignKey("FlatTypeMaster")]
        public Int64 FlatTypeMasterID { get; set; }
        public FlatTypeMaster FlatTypeMaster { get; set; }

        [Required]
        [ForeignKey("FloorMaster")]
        public Int64 FloorMasterID { get; set; }
        public FloorMaster FloorMaster { get; set; }

        [Required]
        public string FlatNo { get; set; }

        [Required]
        public string FlatName { get; set; }

        public Int64 CarpetArea { get; set; }

        public Int64 BuiltupArea { get; set; }

        public bool IsSold { get; set; }

        public Int64 PossesionDate { get; set; }

        public bool VisitorVerificationRequired { get; set; }

        public decimal Maintenance { get; set; }

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
