using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityService.DATA
{
    [Table("RawDataTrain")]
    public class RawDataTrain
    {
        [Key]
        public Int64 Id { get; set; }
        public string TrainNo { get; set; }
        public string TrainName { get; set; }
        public string Sequence { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
        public string Distance { get; set; }
        public string SourceStationCode { get; set; }
        public string SourceStationName { get; set; }
        public string DestinationStationCode { get; set; }
        public string DestinationStationName { get; set; }
    }
}
