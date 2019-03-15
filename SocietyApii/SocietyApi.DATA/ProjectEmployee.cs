﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("ProjectEmployee")]
    public class ProjectEmployee : BaseModel
    {
        [Key]
        public Int64 ProjectEmployeeID { get; set; }

        [Required]
        [ForeignKey("ProjectMaster")]
        public Int64 ProjectID { get; set; }
        public ProjectMaster ProjectMaster { get; set; }

        [Required]
        [ForeignKey("EmployeeMaster")]
        public Int64 EmployeeID { get; set; }
        public EmployeeMaster EmployeeMaster { get; set; }

        [Required]
        [ForeignKey("DesignationMaster")]
        public Int64 DesignationID { get; set; }
        public DesignationMaster DesignationMaster { get; set; }

    }
}
