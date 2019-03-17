using System.Collections.Generic; 
namespace SocietyApi.DTO
{
    public class ResponseDTO : IResponseDTO
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<ErrorMessageDTO> ErrorMessages { get; set; }
        public string applicationId { get; set; }
        public string applicationToken { get; set; }
        public string companyId { get; set; }

    }
}
