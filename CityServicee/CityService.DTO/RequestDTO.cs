namespace CityService.DTO
{
    public class RequestDTO : IRequestDTO
    {
        public long applicationId { get; set; }
        public string applicationToken { get; set; }
    }
}
