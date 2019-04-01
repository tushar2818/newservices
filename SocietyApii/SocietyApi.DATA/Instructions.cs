using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("Instructions")]
    public class Instructions 
    {
        [Key]
        public Int64 InstructionID { get; set; }

        [Required]
        [ForeignKey("ProjectMaster")]
        public Int64 ProjectMasterID { get; set; }
        public ProjectMaster ProjectMaster { get; set; }

        [Required]
        [ForeignKey("DesignationMaster")]
        public Int64 DesignationMasterID { get; set; }
        public DesignationMaster DesignationMaster { get; set; }

        [Required]
        public string Instruction { get; set; }

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
