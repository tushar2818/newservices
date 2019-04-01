using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("LookupMaster")]
    public class LookupMaster 
    {
        [Key]
        public Int64 LookupMasterID { get; set; }

        [Required]
        [ForeignKey("LookupKey")]
        public Int64 LookupKeyID { get; set; }
        public LookupKey LookupKey { get; set; }

        public string LookupMasterName { get; set; }

        public string FilterQuery { get; set; }

        public string GroupBy { get; set; }

        public string OrderBy { get; set; }

        public string DisplayField { get; set; }

        public string ValueField { get; set; }

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
