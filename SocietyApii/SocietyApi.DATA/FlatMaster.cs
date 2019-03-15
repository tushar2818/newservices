using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("FlatMaster")]
    public class FlatMaster : BaseModel
    {
        [Key]
        public Int64 FlatMasterID { get; set; }

        public string FlatNo { get; set; }

        public string CarpetArea { get; set; }

        public string BuiltupArea { get; set; }

        [Required]
        [ForeignKey("WingMaster")]
        public Int64 WingMasterID { get; set; }
        public WingMaster WingMaster { get; set; }

        [Required]
        [ForeignKey("FloorMaster")]
        public Int64 FloorMasterID { get; set; }
        public FloorMaster FloorMaster { get; set; }

        [Required]
        [ForeignKey("FlatTypeMaster")]
        public Int64 FlatTypeMasterID { get; set; }
        public FlatTypeMaster FlatTypeMaster { get; set; }

        [Required]
        [ForeignKey("EmployeeMasterOwner")]
        public Int64 EmployeeMasterOwnerID { get; set; }
        public EmployeeMaster EmployeeMasterOwner { get; set; }

        [ForeignKey("EmployeeMasterRental")]
        public Int64 EmployeeMasterRentalID { get; set; }
        public EmployeeMaster EmployeeMasterRental { get; set; }

        public string PossesionDate { get; set; }
        public string Maintenance { get; set; }
    }
}
