using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("PriorityType")]
    public class PriorityType 
    {
        [Key]
        public Int64 PriorityTypeID { get; set; }

        [Required]
        public string PriorityTypeKey { get; set; }

        [Required]
        public string PriorityTypeValue { get; set; }

        public string PriorityTypeValueHind { get; set; }

        public string PriorityTypeValueMar { get; set; }

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
