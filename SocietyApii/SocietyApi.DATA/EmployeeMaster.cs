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
        public string UserID { get; set; }

        [Required]
        [ForeignKey("CompanyMaster")]
        public Int64 CompanyMasterID { get; set; }
        public CompanyMaster CompanyMaster { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string MobileNo { get; set; }

    }
}
