using System;

namespace SocietyApi.DTO
{
    public class CompanyMasterDTO : BaseModelDTO
    {
        public Int64 CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string LandLine { get; set; }
        public string Mobile { get; set; }
        public string CIN { get; set; }
        public string PAN { get; set; }
        public string GST { get; set; }
        public string Address { get; set; }
    } 
}
