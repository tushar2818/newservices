using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("ComplaintMasterFields")]
    public class ComplaintMasterFields 
    {
        [Key]
        public Int64 ComplaintMasterFieldID { get; set; }

        [Required]
        [ForeignKey("ComplaintMaster")]
        public Int64 ComplaintMasterID { get; set; }
        public ComplaintMaster ComplaintMaster { get; set; }

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
