using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("VisitorColleagues")]
    public class VisitorColleagues 
    {
        [Key]
        public Int64 VisitorColleagueID { get; set; }

        [Required]
        [ForeignKey("VisitorMaster")]
        public Int64 VisitorMasterID { get; set; }
        public VisitorMaster VisitorMaster { get; set; }

        [Required]
        [ForeignKey("VisitorPerson")]
        public Int64 VisitorPersonID { get; set; }
        public VisitorPerson VisitorPerson { get; set; }

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
