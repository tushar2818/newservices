using System;
using System.Collections.Generic;
using System.Text;

namespace CityService.DTO
{
    public class BusStopDTO
    {
        public Int32 Id { get; set; }
        public Int32 Sequence { get; set; }
        public string StopName { get; set; }
        public string StopNameInOL { get; set; }
        public string DistanceFromSource { get; set; }
        public string DistanceFromSourceInOL { get; set; }
        public string Time { get; set; }
        public string TimeInOL { get; set; }
    }
}
