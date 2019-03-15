using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("ProjectMaster")]
    public class ProjectMaster : BaseModel
    {
        [Key]
        public Int64 ProjectMasterID { get; set; }

        [Required]
        [ForeignKey("CompanyMaster")]
        public Int64 CompanyMasterID { get; set; }
        public CompanyMaster CompanyMaster { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public string Address { get; set; }

        public string RERANo { get; set; }
    }
}
