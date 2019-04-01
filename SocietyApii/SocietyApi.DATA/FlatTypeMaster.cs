using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("FlatTypeMaster")]
    public class FlatTypeMaster 
    {
        [Key]
        public Int64 FlatTypeMasterID { get; set; }

        [Required]
        public string FlatType { get; set; }

        public string FlatType2 { get; set; }

        public string FlatType3 { get; set; }

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
