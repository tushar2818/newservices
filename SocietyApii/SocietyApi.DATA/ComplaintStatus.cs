using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("ComplaintStatus")]
    public class ComplaintStatus 
    {
        [Key]
        public Int64 ComplaintStatusID { get; set; }

        [Required]
        [ForeignKey("ComplaintMaster")]
        public Int64 ComplaintMasterID { get; set; }
        public ComplaintMaster ComplaintMaster { get; set; }

        [Required]
        [ForeignKey("ComplaintProgressType")]
        public Int64 ComplaintProgressTypeID { get; set; }
        public ComplaintProgressType ComplaintProgressType { get; set; }

        [Required]
        [ForeignKey("UpdatedPersonMaster")]
        public Int64 UpdatedPersonMasterID { get; set; }
        public PersonMaster UpdatedPersonMaster { get; set; }

        [ForeignKey("AssignedPersonMaster")]
        public Nullable<Int64> AssignedPersonMasterID { get; set; }
        public PersonMaster AssignedPersonMaster { get; set; }

        [Required]
        [ForeignKey("PriorityType")]
        public Int64 PriorityTypeID { get; set; }
        public PriorityType PriorityType { get; set; }

        public string ComplaintInstrunctions { get; set; }

        public string ComplaintDetails { get; set; }

        public bool IsChargable { get; set; }

        public string ChargableDetails { get; set; }

        public decimal ChargableAmount { get; set; }

        public bool IsResolved { get; set; }

        public string ResolveDetails { get; set; }

        [Required]
        public string ProgressTextForSource { get; set; }

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
