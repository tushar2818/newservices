namespace SocietyApi.DTO
{
    public class RequestDTO : IRequestDTO
    {
        public string applicationId { get; set; }
        public string applicationToken { get; set; }
    }
}
