using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("ComplaintMaster")]
    public class ComplaintMaster 
    {
        [Key]
        public Int64 ComplaintMasterID { get; set; }

        [Required]
        public string ComplaintMasterAutoID { get; set; }

        [Required]
        [ForeignKey("ComplaintFromPersonMaster")]
        public Int64 ComplaintFromPersonMasterID { get; set; }
        public PersonMaster ComplaintFromPersonMaster { get; set; }

        [ForeignKey("FlatMaster")]
        public Nullable<Int64> FlatMasterID { get; set; }
        public FlatMaster FlatMaster { get; set; }

        [Required]
        [ForeignKey("ComplaintType")]
        public Int64 ComplaintTypeID { get; set; }
        public ComplaintType ComplaintType { get; set; }

        [Required]
        [ForeignKey("PriorityType")]
        public Int64 PriorityTypeID { get; set; }
        public PriorityType PriorityType { get; set; }

        public string ComplaintDetails { get; set; }        

        public bool IsResolved { get; set; }

        public string ResolvedComment { get; set; }

        public string Feedback { get; set; }

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
