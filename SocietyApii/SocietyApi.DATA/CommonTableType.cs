using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("CommonTableType")]
    public class CommonTableType 
    {
        //Building, Client, Company, Flat, Gate,Person, Project, Wing, Complaint

        [Key]
        public Int64 CommonTableTypeID { get; set; }

        [Required]
        public string CommonTableTypeKey { get; set; }

        [Required]
        public string CommonTableTypeValue { get; set; }

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
