using SocietyApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface IFloorMasterRepository : IBaseRepository
    {
        Task<object> CreateDatabaseAsync();
        Task<IList<FloorMasterDTO>> GetAllAsync();
        Task<FloorMasterDTO> SaveUpdateAsync(FloorMasterDTO modelDTO);
        Task<FloorMasterDTO> GetByIdAsync(long Id);
        Task<FloorMasterDTO> DeleteAsync(long Id);
    }
}
