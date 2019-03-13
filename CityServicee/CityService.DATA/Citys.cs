using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityService.DATA
{
    [Table("Citys")]
    public class Citys : BaseModel
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        public string CityType { get; set; }

        [Required]
        public string CityName { get; set; }


        [ForeignKey("CityState")]
        public Nullable<Int64> StateId { get; set; }
        public Citys CityState { get; set; }

        [ForeignKey("CityDistrict")]
        public Nullable<Int64> DistrictId { get; set; }
        public Citys CityDistrict { get; set; }

        [ForeignKey("CityTaluka")]
        public Nullable<Int64> TalukaId { get; set; }
        public Citys CityTaluka { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string PinCode { get; set; }
        public string MPopulation { get; set; }
        public string FPopulation { get; set; }
    } 
}
