using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("ProjectMaster")]
    public class ProjectMaster : BaseModel
    {
        [Key]
        public Int64 ProjectID { get; set; }

        [Required]
        [ForeignKey("CompanyMaster")]
        public Int64 CompanyID { get; set; }
        public CompanyMaster CompanyMaster { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public string Address { get; set; }

        public string RERANo { get; set; }
    }
}
