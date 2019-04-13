using System;

namespace SocietyApi.DTO
{
    public class RequestDTO : IRequestDTO
    {
        public string Token { get; set; }
        public Int64 ClientID { get; set; }
        public Int64 CompanyID { get; set; }
        public string UserID { get; set; }
        public Int64 PersonID { get; set; }
        public Int64 ProjectID { get; set; }
    }
}
