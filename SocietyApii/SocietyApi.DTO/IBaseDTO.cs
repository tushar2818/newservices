namespace SocietyApi.DTO
{
    public interface IBaseDTO
    {
        string applicationId { get; set; }
        string applicationToken { get; set; }
        string companyId { get; set; } 
    }
}
