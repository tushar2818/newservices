using CityService.DTO;
using System;

namespace CityService.BAL
{
    public interface IBaseRepository : IDisposable
    {
        IRequestDTO Request { get; set; }
        bool IsSuccess { get; set; }
    }
}
