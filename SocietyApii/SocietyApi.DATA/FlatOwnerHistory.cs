using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("FlatOwnerHistory")]
    public class FlatOwnerHistory : BaseModel
    {
        [Key]
        public Int64 FlatOwnerHistoryID { get; set; }


        [ForeignKey("FlatMaster")]
        public Int64 FlatMasterID { get; set; }
        public FlatMaster FlatMaster { get; set; }


        [ForeignKey("EmployeeMaster")]
        public Int64 EmployeeMasterID { get; set; }
        public EmployeeMaster EmployeeMaster { get; set; }

        public string OwnerOrRental { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
