using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("CommonDesignation")]
    public class CommonDesignation 
    {
        //Building Designation, Client Designation, Company Designation, 
        //Flat Designation, Gate Designation, Project Designation, Wing Designation,
        [Key]
        public Int64 CommonDesignationID { get; set; }

        [Required]
        [ForeignKey("CommonTableType")]
        public Int64 CommonTableTypeID { get; set; }
        public CommonTableType CommonTableType { get; set; }

        [Required]
        public Int64 SourceID { get; set; }

        [Required]
        [ForeignKey("PersonMaster")]
        public Int64 PersonID { get; set; }
        public PersonMaster PersonMaster { get; set; }

        [Required]
        [ForeignKey("DesignationMaster")]
        public Int64 DesignationMasterID { get; set; }
        public DesignationMaster DesignationMaster { get; set; }

        [Required]
        public Int64 FromDate { get; set; }
        public Int64 ToDate { get; set; }

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
