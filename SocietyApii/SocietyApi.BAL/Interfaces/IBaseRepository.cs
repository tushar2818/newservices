using SocietyApi.DTO;
using System;
using System.Collections.Generic;

namespace SocietyApi.BAL
{
    public interface IBaseRepository : IDisposable
    {
        IRequestDTO Request { get; set; }
        bool IsSuccess { get; set; }
        List<ErrorMessageDTO> ErrorMessages { get; set; }
        string DisplayMessage { get; set; }
    }
}
