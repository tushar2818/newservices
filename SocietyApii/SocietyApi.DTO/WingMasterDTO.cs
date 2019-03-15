using System;

namespace SocietyApi.DTO
{
    public class WingMasterDTO : BaseModelDTO
    {
        public Int64 WingID { get; set; }
        public string WingName { get; set; }
        public Int64 ProjectID { get; set; }
        public ProjectMasterDTO ProjectMaster { get; set; }
    }
}
