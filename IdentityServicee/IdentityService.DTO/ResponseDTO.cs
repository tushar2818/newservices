using System.Collections.Generic; 
namespace IdentityService.DTO
{
    public class ResponseDTO : IResponseDTO
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<ErrorMessageDTO> ErrorMessages { get; set; } = new List<ErrorMessageDTO>() { new ErrorMessageDTO() { Code = "", Message = "" } };
        public string applicationId { get; set; }
        public string applicationToken { get; set; }
        public string userID { get; set; }
    }
}
