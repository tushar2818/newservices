using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("EmployeeMaster")]
    public class EmployeeMaster : BaseModel
    {
        [Key]
        public Int64 EmployeeMasterID { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string DisplayName { get; set; }

        [Required]
        [ForeignKey("DesignationMaster")]
        public Int64 DesignationMasterID { get; set; }
        public DesignationMaster DesignationMaster { get; set; }

        public string Email { get; set; }

        public string MobileNo { get; set; }
    }
}
