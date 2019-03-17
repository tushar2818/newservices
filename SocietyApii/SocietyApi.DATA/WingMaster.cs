using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("WingMaster")]
    public class WingMaster : BaseModel
    {
        [Key]
        public Int64 WingMasterID { get; set; }

        [Required]
        public string WingName { get; set; }

        [Required]
        [ForeignKey("SocietyMaster")]
        public Int64 SocietyMasterID { get; set; }
        public SocietyMaster SocietyMaster { get; set; }
    }

}
