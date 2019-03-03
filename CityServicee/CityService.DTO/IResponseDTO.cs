using System.Collections.Generic; 
namespace CityService.DTO
{
    public interface IResponseDTO : IBaseDTO
    {
        bool IsSuccess { get; set; }
        object Result { get; set; }
        List<ErrorMessageDTO> ErrorMessages { get; set; }
    }
}
