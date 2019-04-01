using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("ComplaintType")]
    public class ComplaintType 
    {
        [Key]
        public Int64 ComplaintTypeID { get; set; }

        [Required]
        public string ComplaintTypeValue { get; set; }

        public string ComplaintTypeValueHin { get; set; }

        public string ComplaintTypeValueMar { get; set; }

        [ForeignKey("ParentComplaintType")]
        public Nullable<Int64> ParentComplaintTypeID { get; set; }
        public ComplaintType ParentComplaintType { get; set; }

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
