using System;

namespace CityService.DTO
{
    public class BusStandMasterDTO : BaseModelDTO
    {
        public Int64 Id { get; set; }
        public Int64 CityId { get; set; }
        public string StandName { get; set; }
        public string StandNameInOL { get; set; }
        public object Citys { get; set; }
    }
}
