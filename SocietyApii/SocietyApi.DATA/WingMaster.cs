using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("WingMaster")]
    public class WingMaster : BaseModel
    {
        [Key]
        public Int64 WingID { get; set; }

        [Required]
        public string WingName { get; set; }

        [Required]
        [ForeignKey("ProjectMaster")]
        public Int64 ProjectID { get; set; }
        public ProjectMaster ProjectMaster { get; set; }
    }
}
