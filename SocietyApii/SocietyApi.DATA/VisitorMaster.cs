using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("VisitorMaster")]
    public class VisitorMaster 
    {
        [Key]
        public Int64 VisitorID { get; set; }

        [Required]
        public string VisitorAutoID { get; set; }

        [ForeignKey("VisitorAppoinment")]
        public Nullable<Int64> VisitorAppoinmentID { get; set; }
        public VisitorAppoinment VisitorAppoinment { get; set; }

        [ForeignKey("VisitorPerson")]
        public Nullable<Int64> VisitorPersonID { get; set; }
        public VisitorPerson VisitorPerson { get; set; }

        [ForeignKey("ToMeetPersonMaster")]
        public Nullable<Int64> ToMeetPersonMasterID { get; set; }
        public PersonMaster ToMeetPersonMaster { get; set; }

        public int NoOfPerson { get; set; }

        public bool VisitorVerificationRequired { get; set; }

        [ForeignKey("VerifiedPersonMaster")]
        public Nullable<Int64> VerifiedPersonMasterID { get; set; }
        public PersonMaster VerifiedPersonMaster { get; set; }

        public bool EntryGranted { get; set; }

        public bool PassGenerated { get; set; }

        [Required]
        public Int64 InDate { get; set; }

        [Required]
        [ForeignKey("InGateMaster")]
        public Int64 InGateMasterID { get; set; }
        public GateMaster InGateMaster { get; set; }

        [Required]
        [ForeignKey("InPersonMaster")]
        public Int64 InPersonMasterID { get; set; }
        public PersonMaster InPersonMaster { get; set; }

        public Int64 OutDate { get; set; }

        [ForeignKey("OutGateMaster")]
        public Nullable<Int64> OutGateMasterID { get; set; }
        public GateMaster OutGateMaster { get; set; }

        [ForeignKey("OutPersonMaster")]
        public Nullable<Int64> OutPersonMasterID { get; set; }
        public PersonMaster OutPersonMaster { get; set; }

        public string Details { get; set; }

        public string Documents { get; set; }

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
