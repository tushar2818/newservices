using System;

namespace SocietyApi.DTO
{
    public class ClientMasterDTO : BaseModelDTO
    {
        public Int64 ClientMasterID { get; set; }
        public string UserID { get; set; } 
        public string ClientName { get; set; } 
        public string Address { get; set; }         
        public string Email { get; set; } 
        public string Mobile { get; set; } 
        public Int64 VallidFrom { get; set; }
        public Int64 VallidTill { get; set; } 
        public Int64 CompanyLimit { get; set; } 
        public Int64 ProjectLimit { get; set; } 
        public Int64 BuildingLimit { get; set; } 
        public Int64 WingLimit { get; set; } 
        public Int64 FlatLimit { get; set; } 
        public string ContactPerson { get; set; } 
        public string ContactPersonMobile { get; set; }
        public string Website { get; set; } 
        public string ClientDetails { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; } 
    }
}
