using System;

namespace SocietyApi.DTO
{
    public class FlatMasterDTO : BaseModelDTO
    {
        public Int64 FlatID { get; set; }
        public string FlatNo { get; set; }
        public string CarpetArea { get; set; }
        public string BuiltupArea { get; set; }
        public Int64 WingID { get; set; }
        public WingMasterDTO WingMaster { get; set; }
        public Int64 FloorID { get; set; }
        public FloorMasterDTO FloorMaster { get; set; }
        public Int64 FlatTypeID { get; set; }
        public FlatTypeMasterDTO FlatTypeMaster { get; set; }
        public Int64 OwnerID { get; set; }
        public EmployeeMasterDTO EmployeeMasterOwner { get; set; }
        public Int64 RentalID { get; set; }
        public EmployeeMasterDTO EmployeeMasterRental { get; set; }
        public string PossesionDate { get; set; }
        public string Maintenance { get; set; }
    }
}
