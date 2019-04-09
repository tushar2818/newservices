using SocietyApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface IFlatTypeMasterRepository : IBaseRepository
    {
        Task<IList<FlatTypeMasterDTO>> GetAllAsync();
        Task<FlatTypeMasterDTO> SaveUpdateAsync(FlatTypeMasterDTO modelDTO);
        Task<FlatTypeMasterDTO> GetByIdAsync(long Id);
        Task<FlatTypeMasterDTO> DeleteAsync(long Id);
    }
}
