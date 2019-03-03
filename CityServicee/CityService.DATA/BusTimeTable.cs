using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityService.DATA
{
    //city level
    [Table("BusTimeTable")]
    public class BusTimeTable : BaseModel
    {
        [Key]
        public Int64 Id { get; set; }

        [ForeignKey("Citys")]
        public Int64 CityId { get; set; }
        public virtual Citys Citys { get; set; }

        [ForeignKey("BusStandMaster")]
        public Int64 BusStandId { get; set; }
        public virtual BusStandMaster BusStandMaster { get; set; }

        [ForeignKey("BusTypeMaster")]
        public Int64 BusTypeId { get; set; }
        public virtual BusTypeMaster BusTypeMaster { get; set; }

        [ForeignKey("SourceCitys")]
        public Int64 SourceCityId { get; set; }
        public virtual Citys SourceCitys { get; set; }

        [ForeignKey("DestinationCitys")]
        public Int64 DestinationCityId { get; set; }
        public virtual Citys DestinationCitys { get; set; }

        public string Via { get; set; }
        public string ViaInOL { get; set; }

        [Required]
        public string Times { get; set; }
        [Required]
        public string TimesInOL { get; set; }
        public string BusStopsJson { get; set; }
    }
}
