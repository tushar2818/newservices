using System;

namespace SocietyApi.DTO
{
    public class EmployeeMasterDTO : BaseModelDTO
    {
        public Int64 EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public Int64 DesignationID { get; set; }
        public DesignationMasterDTO DesignationMaster { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
    }
}
