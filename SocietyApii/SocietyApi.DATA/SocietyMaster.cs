using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("SocietyMaster")]
    public class SocietyMaster : BaseModel
    {
        [Key]
        public Int64 SocietyMasterID { get; set; }

        [Required]
        public string SocietyName { get; set; }

        [Required]
        [ForeignKey("ProjectMaster")]
        public Int64 ProjectMasterID { get; set; }
        public ProjectMaster ProjectMaster { get; set; }
    }
}
