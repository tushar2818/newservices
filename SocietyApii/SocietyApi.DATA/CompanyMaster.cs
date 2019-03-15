using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("CompanyMaster")]
    public class CompanyMaster : BaseModel
    {
        [Key]
        public Int64 CompanyID { get; set; }

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
    } 
}
