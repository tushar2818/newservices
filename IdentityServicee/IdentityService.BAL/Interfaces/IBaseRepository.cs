using IdentityService.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityService.BAL
{
    public interface IBaseRepository : IDisposable
    {
        IRequestDTO Request { get; set; }
        bool IsSuccess { get; set; }
        List<ErrorMessageDTO> ErrorMessages { get; set; }
        string DisplayMessage { get; set; }        
    }
}
