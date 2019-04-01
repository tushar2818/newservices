using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("GateMaster")]
    public class GateMaster 
    {
        [Key]
        public Int64 GateID { get; set; }

        [Required]
        [ForeignKey("ProjectMaster")]
        public Int64 ProjectMasterID { get; set; }
        public ProjectMaster ProjectMaster { get; set; }

        [Required]
        public string GateName { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

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
