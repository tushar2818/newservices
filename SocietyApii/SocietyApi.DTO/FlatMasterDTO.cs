using System;

namespace SocietyApi.DTO
{
    public class FlatMasterDTO : BaseModelDTO
    {
        public Int64 FlatMasterID { get; set; }
        public string FlatNo { get; set; }
        public string CarpetArea { get; set; }
        public string BuiltupArea { get; set; }
        public string PossesionDate { get; set; }
        public string Maintenance { get; set; }
        public Int64 WingMasterID { get; set; }
        public WingMasterDTO WingMaster { get; set; }
        public Int64 FloorMasterID { get; set; }
        public FloorMasterDTO FloorMaster { get; set; }
        public Int64 FlatTypeMasterID { get; set; }
        public FlatTypeMasterDTO FlatTypeMaster { get; set; }
    }
}
