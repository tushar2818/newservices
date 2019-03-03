using System;

namespace CityService.DTO
{
    public class BusTimeTableDTO : BaseModelDTO
    {
        public Int64 Id { get; set; }
        public Int64 CityId { get; set; }
        public Int64 BusStandId { get; set; }
        public Int64 BusTypeId { get; set; }
        public Int64 SourceCityId { get; set; }
        public Int64 DestinationCityId { get; set; }
        public string Via { get; set; }
        public string ViaInOL { get; set; }
        public string Times { get; set; }
        public string TimesInOL { get; set; }
        public string BusStopsJson { get; set; }

        public object DestinationCitys { get; set; }
        public object Citys { get; set; }
        public object BusStandMaster { get; set; }
        public object BusTypeMaster { get; set; }
        public object SourceCitys { get; set; }
    }
}
