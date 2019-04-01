namespace SocietyApi.DTO
{
    public class RequestDTO : IRequestDTO
    {
        public string Token { get; set; }
        public string ClientID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
    }
}
