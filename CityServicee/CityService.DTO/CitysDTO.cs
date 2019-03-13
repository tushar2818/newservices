using System;

namespace CityService.DTO
{
    public class CitysDTO : BaseModelDTO
    {        
        public Int64 Id { get; set; }
        public string CityType { get; set; }
        public string CityName { get; set; }
        public Nullable<Int64> StateId { get; set; }
        public Nullable<Int64> DistrictId { get; set; }
        public Nullable<Int64> TalukaId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string PinCode { get; set; }
        public string MPopulation { get; set; }
        public string FPopulation { get; set; }

        public object CityState { get; set; }
        public object CityDistrict { get; set; }
        public object CityTaluka { get; set; }
    }
}
