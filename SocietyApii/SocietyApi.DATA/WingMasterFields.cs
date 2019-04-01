using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("WingMasterFields")]
    public class WingMasterFields 
    {
        [Key]
        public Int64 WingMasterFieldID { get; set; }

        [Required]
        [ForeignKey("WingMaster")]
        public Int64 WingMasterID { get; set; }
        public WingMaster WingMaster { get; set; }

        [Required]
        public string FieldName { get; set; }

        [Required]
        public string FieldValue { get; set; }

        [Required]
        public string FieldDisplayName { get; set; }

        [Required]
        public string FieldType { get; set; }

        public string FieldDetails { get; set; }

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
