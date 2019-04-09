using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("ClientMaster")]
    public class ClientMaster 
    {
        [Key]
        public Int64 ClientMasterID { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }        

        [Required]
        public Int64 VallidFrom { get; set; }

        [Required]
        public Int64 VallidTill { get; set; }

        [Required]
        public Int64 CompanyLimit { get; set; }

        [Required]
        public Int64 ProjectLimit { get; set; }

        [Required]
        public Int64 BuildingLimit { get; set; }

        [Required]
        public Int64 WingLimit { get; set; }

        [Required]
        public Int64 FlatLimit { get; set; }

        [Required]
        public string ContactPerson { get; set; }

        [Required]
        public string ContactPersonMobile { get; set; }

        public string Website { get; set; }

        public string ClientDetails { get; set; }

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
