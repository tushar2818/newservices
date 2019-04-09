using System; 
namespace SocietyApi.DTO
{
    public class CompanyMasterDTO : BaseModelDTO
    {
        public Int64 CompanyMasterID { get; set; }

        public Int64 ClientMasterID { get; set; }
        public ClientMasterDTO ClientMaster { get; set; }

        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string LandLine { get; set; }
        public string Mobile { get; set; }
        public string CIN { get; set; }
        public string PAN { get; set; }
        public string GST { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string CompanyDetails { get; set; }
    }
}
