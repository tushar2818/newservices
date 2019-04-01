using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("VisitorPerson")]
    public class VisitorPerson 
    {
        [Key]
        public Int64 VisitorPersonID { get; set; }

        [Required]
        [ForeignKey("ClientMaster")]
        public Int64 ClientMasterID { get; set; }
        public ClientMaster ClientMaster { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Gender { get; set; }

        public string VehicleNo { get; set; }

        public string Age { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string AadharNo { get; set; }

        public string PanNo { get; set; }

        public string Photo { get; set; }

        public bool IsVerified { get; set; }

        public string Address { get; set; }

        public bool IsBlocked { get; set; }

        [ForeignKey("BlockedPersonMaster")]
        public Nullable<Int64> BlockedPersonMasterID { get; set; }
        public PersonMaster BlockedPersonMaster { get; set; }

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
