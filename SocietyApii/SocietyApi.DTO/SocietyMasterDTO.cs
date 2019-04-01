using System;

namespace SocietyApi.DTO
{
    public class SocietyMasterDTO:BaseModelDTO
    {
        public Int64 SocietyMasterID { get; set; }
        public string SocietyName { get; set; }
        public Int64 ProjectMasterID { get; set; }
        public ProjectMasterDTO ProjectMaster { get; set; }
    }
}
