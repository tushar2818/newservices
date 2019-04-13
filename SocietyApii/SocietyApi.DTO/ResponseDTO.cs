using System;
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
        public Int64 ClientID { get; set; }
        public Int64 CompanyID { get; set; }
        public string UserID { get; set; }
        public Int64 PersonID { get; set; }
        public Int64 ProjectID { get; set; }

    }
}
