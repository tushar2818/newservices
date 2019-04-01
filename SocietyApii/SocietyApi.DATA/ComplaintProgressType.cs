using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("ComplaintProgressType")]
    public class ComplaintProgressType 
    {
        [Key]
        public Int64 ComplaintProgressTypeID { get; set; }

        [Required]
        public string ComplaintTypeKey { get; set; }

        [Required]
        public string ComplaintTypeValue { get; set; }

        public string ComplaintTypeValueHin { get; set; }

        public string ComplaintTypeValueMar { get; set; }

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
