using System;

namespace SocietyApi.DTO
{
    public class ProjectEmployeeDTO : BaseModelDTO
    {
        public Int64 ProjectEmployeeID { get; set; }
        public Int64 ProjectID { get; set; }
        public ProjectMasterDTO ProjectMaster { get; set; }
        public Int64 EmployeeID { get; set; }
        public EmployeeMasterDTO EmployeeMaster { get; set; }
        public Int64 DesignationID { get; set; }
        public DesignationMasterDTO DesignationMaster { get; set; }

    }
}
