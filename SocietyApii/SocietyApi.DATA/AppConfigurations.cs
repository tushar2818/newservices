using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("AppConfigurations")]
    public class AppConfigurations 
    {
        [Key]
        public Int64 AppConfigurationID { get; set; }

        [Required]
        public string ConfigKey { get; set; }

        [Required]
        public string ConfigName { get; set; }

        [Required]
        public string ConfigValue { get; set; }

        [Required]
        [ForeignKey("ProjectMaster")]
        public Int64 ProjectMasterID { get; set; }
        public ProjectMaster ProjectMaster { get; set; }

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
