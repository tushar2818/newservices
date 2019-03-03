using System;

namespace CityService.DTO
{
    public class BusTypeMasterDTO : BaseModelDTO
    {
        public Int64 Id { get; set; }
        public Int64 CityId { get; set; }
        public string BusType { get; set; }
        public string BusTypeInOL { get; set; }
        public object Citys { get; set; }
    }
}
