using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("FloorMaster")]
    public class FloorMaster : BaseModel
    {
        [Key]
        public Int64 FloorID { get; set; }

        [Required]
        public string FloorName { get; set; }
    }
}
