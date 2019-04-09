using SocietyApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface IFlatMasterRepository : IBaseRepository
    {
        Task<IList<FlatMasterDTO>> GetAllAsync();
        Task<FlatMasterDTO> SaveUpdateAsync(FlatMasterDTO modelDTO);
        Task<FlatMasterDTO> GetByIdAsync(long Id);
        Task<FlatMasterDTO> DeleteAsync(long Id);
    }
}
