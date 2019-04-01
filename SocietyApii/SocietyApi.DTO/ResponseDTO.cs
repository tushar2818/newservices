using System.Collections.Generic; 
namespace SocietyApi.DTO
{
    public class ResponseDTO : IResponseDTO
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<ErrorMessageDTO> ErrorMessages { get; set; }

        public string Token { get; set; }
        public string ClientID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
    }
}
