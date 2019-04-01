using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SocietyApi.DATA
{
    [Table("DeviceType")]
    public class DeviceType 
    {
        [Key]
        public Int64 DeviceTypeID { get; set; }

        [Required]
        public string DeviceTypeKey { get; set; }

        [Required]
        public string DeviceTypeValue { get; set; }

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
