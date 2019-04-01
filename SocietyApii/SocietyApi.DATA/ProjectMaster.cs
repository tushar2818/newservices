using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("ProjectMaster")]
    public class ProjectMaster 
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

        public string ReraNo { get; set; }

        public string Latitude { get; set; }

        public string Longiude { get; set; }

        public string Website { get; set; }

        public string ProjectDetails { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public Int64 CreatedDate { get; set; }

        [Required]
        public Int64 UpdatedDate { get; set; }

    }



}
