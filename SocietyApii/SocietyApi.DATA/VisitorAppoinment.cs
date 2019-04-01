using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("VisitorAppoinment")]
    public class VisitorAppoinment 
    {
        [Key]
        public Int64 VisitorAppoinmentID { get; set; }

        [Required]
        public string VisitorAppoinmentAutoID { get; set; }

        [Required]
        [ForeignKey("AppointedPersonMaster")]
        public Int64 AppointedPersonMasterID { get; set; }
        public PersonMaster AppointedPersonMaster { get; set; }

        [Required]
        [ForeignKey("VisitorPerson")]
        public Int64 VisitorPersonID { get; set; }
        public VisitorPerson VisitorPerson { get; set; }

        [Required]
        [ForeignKey("ToMeetFlatMaster")]
        public Nullable<Int64> ToMeetFlatMasterID { get; set; }
        public FlatMaster ToMeetFlatMaster { get; set; }

        [Required]
        [ForeignKey("ToMeetPersonMaster")]
        public Nullable<Int64> ToMeetPersonMasterID { get; set; }
        public PersonMaster ToMeetPersonMaster { get; set; }

        [Required]
        [ForeignKey("VisitorPurposeType")]
        public Int64 VisitorPurposeTypeID { get; set; }
        public VisitorPurposeType VisitorPurposeType { get; set; }

        public string Instructions { get; set; }

        [Required]
        public Int64 VisitDate { get; set; }

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
