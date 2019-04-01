using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("VisitorAppoinmentStatus")]
    public class VisitorAppoinmentStatus 
    {
        [Key]
        public Int64 VisitorAppoinmentStatusID { get; set; }

        [Required]
        [ForeignKey("VisitorMaster")]
        public Int64 VisitorMasterID { get; set; }
        public VisitorMaster VisitorMaster { get; set; }

        [Required]
        [ForeignKey("VisitorAppoinmentStatusType")]
        public Int64 VisitorAppoinmentStatusTypeID { get; set; }
        public VisitorAppoinmentStatusType VisitorAppoinmentStatusType { get; set; }

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
