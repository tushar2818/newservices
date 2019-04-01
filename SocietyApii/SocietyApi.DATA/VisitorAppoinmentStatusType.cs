using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("VisitorAppoinmentStatusType")]
    public class VisitorAppoinmentStatusType 
    {
        [Key]
        public Int64 VisitorAppoinmentStatusTypeID { get; set; }

        [Required]
        public string VisitorAppoinmentStatusKey { get; set; }

        [Required]
        public string VisitorAppoinmentStatusValue { get; set; }

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
