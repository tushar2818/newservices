using System; 

namespace SocietyApi.DTO
{
    public class FlatOwnerHistoryDTO : BaseModelDTO
    {
        public Int64 FlatOwnerHistoryID { get; set; }
        public Int64 FlatMasterID { get; set; }
        public FlatMasterDTO FlatMaster { get; set; }
        public Int64 EmployeeMasterID { get; set; }
        public EmployeeMasterDTO EmployeeMaster { get; set; }
        public string OwnerOrRental { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
