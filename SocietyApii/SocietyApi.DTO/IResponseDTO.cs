using System.Collections.Generic; 
namespace SocietyApi.DTO
{
    public interface IResponseDTO : IBaseDTO
    {
        bool IsSuccess { get; set; }
        object Result { get; set; }
        List<ErrorMessageDTO> ErrorMessages { get; set; }
    }
}
