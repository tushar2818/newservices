using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("CompanyMasterFields")]
    public class CompanyMasterFields 
    {
        [Key]
        public Int64 CompanyMasterFieldID { get; set; }

        [Required]
        [ForeignKey("CompanyMaster")]
        public Int64 CompanyMasterID { get; set; }
        public CompanyMaster CompanyMaster { get; set; }

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
