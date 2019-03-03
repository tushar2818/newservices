using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityService.DATA
{
    //city level
    [Table("BusStandMaster")]
    public class BusStandMaster : BaseModel
    {
        [Key]
        public Int64 Id { get; set; }

        [ForeignKey("Citys")]
        public Int64 CityId { get; set; }
        public virtual Citys Citys { get; set; }

        [Required]
        public string StandName { get; set; }

        [Required]
        public string StandNameInOL { get; set; }
    }
}
