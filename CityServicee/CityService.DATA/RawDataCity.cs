using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityService.DATA
{
    [Table("RawDataCity")]
    public class RawDataCity
    {
        [Key]
        public Int64 Id { get; set; }
        public string Village { get; set; }
        public string PinCode { get; set; }
        public string Type { get; set; }
        public string Taluka { get; set; }
        public string District { get; set; }
        public string State { get; set; }
    }
}
