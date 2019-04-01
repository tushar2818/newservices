using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("CommonDocument")]
    public class CommonDocument 
    {
        //Building Document, Client Document, Company Document, 
        //Flat Document, Gate Document,Person Document, Project Designation, Wing Document,

        [Key]
        public Int64 CommonDocumentID { get; set; }

        [Required]
        [ForeignKey("CommonTableType")]
        public Int64 CommonTableTypeID { get; set; }
        public CommonTableType CommonTableType { get; set; }

        [Required]
        public Int64 SourceID { get; set; }

        [Required]
        [ForeignKey("DocumentType")]
        public Int64 DocumentTypeID { get; set; }
        public DocumentType DocumentType { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }

        public bool IsVisibleToAll { get; set; }

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
