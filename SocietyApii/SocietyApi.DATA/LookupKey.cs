using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    [Table("LookupKey")]
    public class LookupKey 
    {
        [Key]
        public Int64 LookupKeyID { get; set; }

        [Required]
        [ForeignKey("PersonMaster")]
        public Int64 ProjectMasterID { get; set; }
        public PersonMaster PersonMaster { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string Field1DisplayName { get; set; }

        public string Field2DisplayName { get; set; }

        public string Field3DisplayName { get; set; }

        public string Field4DisplayName { get; set; }

        public string Field5DisplayName { get; set; }

        public string Field6DisplayName { get; set; }

        public string Field7DisplayName { get; set; }

        public string Field8DisplayName { get; set; }

        public string Field9DisplayName { get; set; }

        public string Field10DisplayName { get; set; }

        public string Field11DisplayName { get; set; }

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
