using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("MaintainanceFlat")]
    public class MaintainanceFlat 
    {
        [Key]
        public Int64 MaintainanceFlatID { get; set; }

        [Required]
        [ForeignKey("FlatMaster")]
        public Int64 FlatMasterID { get; set; }
        public FlatMaster FlatMaster { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string AmountDetails { get; set; }

        public string Note { get; set; }

        [Required]
        public Int64 FromDate { get; set; }

        [Required]
        public Int64 ToDate { get; set; }

        public decimal AmountPaid { get; set; }

        public decimal AmountRemaining { get; set; }

        public string Status { get; set; }

        public string MaintananceType { get; set; }

        public Int64 MaintananceTypeID { get; set; }

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
