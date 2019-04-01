using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("TemplateMaster")]
    public class TemplateMaster 
    {
        [Key]
        public Int64 TemplateID { get; set; }

        [Required]
        public string TemplateKey { get; set; }

        [Required]
        public string TemplateName { get; set; }

        [Required]
        public string TemplateValue { get; set; }

        [Required]
        [ForeignKey("DeviceType")]
        public Int64 DeviceTypeID { get; set; }
        public DeviceType DeviceType { get; set; }

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
