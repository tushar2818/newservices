using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("VisitorPurposeType")]
    public class VisitorPurposeType 
    {
        [Key]
        public Int64 VisitorPurposeTypeID { get; set; }

        [Required]
        public string VisitorPurposeValue { get; set; }

        public string VisitorPurposeHin { get; set; }

        public string VisitorPurposeMar { get; set; }

        [ForeignKey("ParentVisitorPurposeType")]
        public Nullable<Int64> ParentVisitorPurposeTypeID { get; set; }
        public VisitorPurposeType ParentVisitorPurposeType { get; set; }

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
