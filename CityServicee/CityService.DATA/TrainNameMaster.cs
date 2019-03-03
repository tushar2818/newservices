using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityService.DATA
{
    [Table("TrainNameMaster")]
    public class TrainNameMaster : BaseModel
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        public string TrainName { get; set; }

        [Required]
        public string TrainNumber { get; set; }
    }
}
