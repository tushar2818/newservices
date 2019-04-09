using SocietyApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface ILookupRepository : IBaseRepository
    {
        Task<IList<LookupDetailDTO>> GetLookups(IList<LookupDetailDTO> lookupDetails);
    }
}
