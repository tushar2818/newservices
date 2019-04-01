using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("FloorMaster")]
    public class FloorMaster 
    {
        [Key]
        public Int64 FloorMasterID { get; set; }

        [Required]
        public string FloorName { get; set; }

        public string FloorName2 { get; set; }

        public string FloorName3 { get; set; }

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
