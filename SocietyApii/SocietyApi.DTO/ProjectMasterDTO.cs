using System;

namespace SocietyApi.DTO
{
    public class ProjectMasterDTO : BaseModelDTO
    {
        public Int64 ProjectID { get; set; }
        public Int64 CompanyID { get; set; }
        public CompanyMasterDTO CompanyMaster { get; set; }
        public string ProjectName { get; set; }
        public string Address { get; set; }
        public string RERANo { get; set; }
    }
}
