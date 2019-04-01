using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{

    [Table("CompanyMaster")]
    public class CompanyMaster 
    {
        [Key]
        public Int64 CompanyMasterID { get; set; }

        [Required]
        [ForeignKey("ClientMaster")]
        public Int64 ClientMasterID { get; set; }
        public ClientMaster ClientMaster { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Email { get; set; }

        public string LandLine { get; set; }

        [Required]
        public string Mobile { get; set; }

        public string CIN { get; set; }

        public string PAN { get; set; }

        public string GST { get; set; }

        [Required]
        public string Address { get; set; }

        public string Website { get; set; }

        public string CompanyDetails { get; set; }

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
