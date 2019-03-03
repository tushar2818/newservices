using CityService.DTO;
using System.Collections.Generic;

namespace CityService.BAL
{
    public interface ILookupRepository : IBaseRepository
    {
        object GetLookups(List<LookupDetail> lookupDetails);
    }
}
