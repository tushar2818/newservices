using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("VisitorVisitedFlats")]
    public class VisitorVisitedFlats 
    {
        [Key]
        public Int64 VisitorVisitedFlatID { get; set; }

        [Required]
        [ForeignKey("VisitorMaster")]
        public Int64 VisitorMasterID { get; set; }
        public VisitorMaster VisitorMaster { get; set; }

        [Required]
        [ForeignKey("FlatMaster")]
        public Int64 FlatMasterID { get; set; }
        public FlatMaster FlatMaster { get; set; }

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
