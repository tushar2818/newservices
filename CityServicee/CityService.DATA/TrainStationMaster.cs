using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityService.DATA
{
    [Table("TrainStationMaster")]
    public class TrainStationMaster : BaseModel
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        public string StationName { get; set; }

        [Required]
        public string StationCode { get; set; }
    }
}
