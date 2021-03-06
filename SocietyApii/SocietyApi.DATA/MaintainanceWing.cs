﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("MaintainanceWing")]
    public class MaintainanceWing 
    {
        [Key]
        public Int64 MaintainanceWingID { get; set; }

        [Required]
        [ForeignKey("WingMaster")]
        public Int64 WingMasterID { get; set; }
        public WingMaster WingMaster { get; set; }

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
