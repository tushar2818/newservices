using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("DesignationMaster")]
    public class DesignationMaster : BaseModel
    {
        [Key]
        public Int64 DesignationMasterID { get; set; }

        [Required]
        public string Designation { get; set; }
    }
}
