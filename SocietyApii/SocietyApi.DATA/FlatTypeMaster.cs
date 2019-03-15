using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("FlatTypeMaster")]
    public class FlatTypeMaster : BaseModel
    {
        [Key]
        public Int64 FlatTypeMasterID { get; set; }

        [Required]
        public string FlatType { get; set; }
    }
}
