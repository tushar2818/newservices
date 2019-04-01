using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("VisitorPersonFields")]
    public class VisitorPersonFields 
    {
        [Key]
        public Int64 VisitorPersonFieldID { get; set; }

        [Required]
        [ForeignKey("VisitorPerson")]
        public Int64 VisitorPersonID { get; set; }
        public VisitorPerson VisitorPerson { get; set; }

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
