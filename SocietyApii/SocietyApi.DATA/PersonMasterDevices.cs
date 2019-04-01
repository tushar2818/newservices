using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("PersonMasterDevices")]
    public class PersonMasterDevices 
    {
        [Key]
        public Int64 PersonMasterDeviceID { get; set; }

        [Required]
        [ForeignKey("PersonMaster")]
        public Int64 PersonMasterID { get; set; }
        public PersonMaster PersonMaster { get; set; }

        [Required]
        public string DeviceID { get; set; }

        public string Field1 { get; set; }

        public string Field2 { get; set; }

        public string Field3 { get; set; }

        public string DeviceDetails { get; set; }

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
