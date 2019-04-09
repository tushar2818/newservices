using System;

namespace SocietyApi.DTO
{
    public class FlatMasterDTO : BaseModelDTO
    {
        public Int64 FlatMasterID { get; set; } 

        public Int64 WingMasterID { get; set; }
        public WingMasterDTO WingMaster { get; set; } 

        public Int64 FlatTypeMasterID { get; set; }
        public FlatTypeMasterDTO FlatTypeMaster { get; set; }

        public Int64 FloorMasterID { get; set; }
        public FloorMasterDTO FloorMaster { get; set; }

        public string FlatNo { get; set; } 
        public string FlatName { get; set; } 
        public Int64 CarpetArea { get; set; } 
        public Int64 BuiltupArea { get; set; } 
        public bool IsSold { get; set; }
        public Int64 PossesionDate { get; set; }
        public bool VisitorVerificationRequired { get; set; }
        public decimal Maintenance { get; set; }
    }
}
