using System; 

namespace SocietyApi.DTO
{
    public class PersonMasterDTO : BaseModelDTO
    {
        public Int64 PersonMasterID { get; set; }

        public Int64 ClientMasterID { get; set; }
        public ClientMasterDTO ClientMaster { get; set; }

        public string UserID { get; set; } 
        public string FirstName { get; set; } 
        public string MiddleName { get; set; } 
        public string LastName { get; set; } 
        public string DisplayName { get; set; } 
        public string Email { get; set; } 
        public string MobileNo { get; set; } 
        public string PanNo { get; set; } 
        public string AadharNo { get; set; } 
        public bool VisitorVerificationRequired { get; set; }  
    }
}
