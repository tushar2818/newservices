namespace SocietyApi.DTO
{
    public interface IBaseDTO
    {
        string Token { get; set; }
        string ClientID { get; set; }
        string CompanyID { get; set; }
        string UserID { get; set; }
    }
}
