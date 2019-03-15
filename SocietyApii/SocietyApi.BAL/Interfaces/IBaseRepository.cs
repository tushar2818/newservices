using SocietyApi.DTO;
using System;

namespace SocietyApi.BAL
{
    public interface IBaseRepository : IDisposable
    {
        IRequestDTO Request { get; set; }
        bool IsSuccess { get; set; }
    }
}
