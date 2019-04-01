using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyApi.DATA
{
    //vendor list
    [Table("ComplaintTypePersons")]
    public class ComplaintTypePersons 
    {
        [Key]
        public Int64 VendorTypePersonID { get; set; }

        [ForeignKey("ComplaintType")]
        public Int64 ComplaintTypeID { get; set; }
        public ComplaintType ComplaintType { get; set; }

        [ForeignKey("PersonMaster")]
        public Int64 PersonMasterID { get; set; }
        public PersonMaster PersonMaster { get; set; }

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
