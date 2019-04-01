using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("LookupData")]
    public class LookupData 
    {
        [Key]
        public Int64 LookupDataID { get; set; }

        [Required]
        [ForeignKey("LookupKey")]
        public Int64 LookupKeyID { get; set; }
        public LookupKey LookupKey { get; set; }

        public string Field1 { get; set; }

        public string Field2 { get; set; }

        public string Field3 { get; set; }

        public string Field4 { get; set; }

        public string Field5 { get; set; }

        public string Field6 { get; set; }

        public string Field7 { get; set; }

        public string Field8 { get; set; }

        public string Field9 { get; set; }

        public string Field10 { get; set; }

        public string Field11 { get; set; }

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
