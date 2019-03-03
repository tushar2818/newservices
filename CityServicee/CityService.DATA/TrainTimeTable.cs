using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityService.DATA
{
    [Table("TrainTimeTable")]
    public class TrainTimeTable : BaseModel
    {
        [Key]
        public Int64 Id { get; set; }

        [ForeignKey("TrainNameMaster")]
        public Int64 TrainId { get; set; }
        public virtual TrainNameMaster TrainNameMaster { get; set; }

        [ForeignKey("TrainStationMaster")]
        public Int64 StationId { get; set; }
        public virtual TrainStationMaster TrainStationMaster { get; set; }

        [Required]
        public string TimeArrival { get; set; }
        [Required]
        public string TimeDeparture { get; set; }
        [Required]
        public string Distance { get; set; }


        [ForeignKey("SourceTrainStationMaster")]
        public Int64 SourceStationId { get; set; }
        public virtual TrainStationMaster SourceTrainStationMaster { get; set; }

        [ForeignKey("DestinationTrainStationMaster")]
        public Int64 DestinationStationId { get; set; }
        public virtual TrainStationMaster DestinationTrainStationMaster { get; set; }
    }
}
