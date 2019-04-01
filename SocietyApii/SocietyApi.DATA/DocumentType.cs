using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("DocumentType")]
    public class DocumentType 
    {
        [Key]
        public Int64 DocumentTypeID { get; set; }

        [Required]
        public string DocumentTypeKey { get; set; }

        [Required]
        public string DocumentTypeValue { get; set; }

        public string DocumentTypeValueHin { get; set; }

        public string DocumentTypeValueMar { get; set; }

        [Required]
        public string DocumentTypeIcon { get; set; }

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
