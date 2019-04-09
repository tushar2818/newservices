using System;

namespace SocietyApi.DTO
{
    public class WingMasterDTO : BaseModelDTO
    {
        public Int64 WingMasterID { get; set; }

        public Int64 BuildingMasterID { get; set; }
        public BuildingMasterDTO BuildingMaster { get; set; }

        public string WingName { get; set; }
        public Int64 NoOfFloor { get; set; }
    }
}
