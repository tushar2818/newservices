using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("PersonMaster")]
    public class PersonMaster 
    {
        [Key]
        public Int64 PersonMasterID { get; set; }

        [Required]
        [ForeignKey("ClientMaster")]
        public Int64 ClientMasterID { get; set; }
        public ClientMaster ClientMaster { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string MobileNo { get; set; }

        public string PanNo { get; set; }

        public string AadharNo { get; set; }

        public bool VisitorVerificationRequired { get; set; }

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
