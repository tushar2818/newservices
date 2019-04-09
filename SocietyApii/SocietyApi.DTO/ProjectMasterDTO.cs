using System;

namespace SocietyApi.DTO
{
    public class ProjectMasterDTO : BaseModelDTO
    {
        public Int64 ProjectMasterID { get; set; }

        public Int64 CompanyMasterID { get; set; }
        public CompanyMasterDTO CompanyMaster { get; set; }

        public string ProjectName { get; set; }
        public string Address { get; set; }
        public string ReraNo { get; set; }
        public string Latitude { get; set; }
        public string Longiude { get; set; }
        public string Website { get; set; }
        public string ProjectDetails { get; set; } 
    }
}
