using System;

namespace SocietyApi.DTO
{
    public class ProjectEmployeeDTO : BaseModelDTO
    {
        public Int64 ProjectEmployeeID { get; set; }

        public Int64 ProjectMasterID { get; set; }
        public ProjectMasterDTO ProjectMaster { get; set; }

        public Int64 EmployeeMasterID { get; set; }
        public EmployeeMasterDTO EmployeeMaster { get; set; }

        public Int64 DesignationMasterID { get; set; }
        public DesignationMasterDTO DesignationMaster { get; set; }

    }
}
