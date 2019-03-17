using System;

namespace SocietyApi.DTO
{
    public class WingMasterDTO : BaseModelDTO
    {
        public Int64 WingMasterID { get; set; }
        public string WingName { get; set; }
        public Int64 SocietyMasterID { get; set; }
        public SocietyMasterDTO SocietyMaster { get; set; }
    }
}
