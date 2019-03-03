using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityService.DATA
{
    //state level
    [Table("BusTypeMaster")]
    public class BusTypeMaster : BaseModel
    {
        [Key]
        public Int64 Id { get; set; }

        [ForeignKey("Citys")]
        public Int64 CityId { get; set; }
        public virtual Citys Citys { get; set; }

        [Required]
        public string BusType { get; set; }
        [Required]
        public string BusTypeInOL { get; set; }
    }
}
