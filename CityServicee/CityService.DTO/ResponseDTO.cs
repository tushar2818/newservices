using System.Collections.Generic; 
namespace CityService.DTO
{
    public class ResponseDTO : IResponseDTO
    {
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
        public string DisplayMessage { get; set; }
        public List<ErrorMessageDTO> ErrorMessages { get; set; }
        public long applicationId { get; set; }
        public string applicationToken { get; set; }
    }
}
