using SocietyApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface IBuildingMasterRepository : IBaseRepository
    {
        Task<IList<BuildingMasterDTO>> GetAllAsync();
        Task<BuildingMasterDTO> SaveUpdateAsync(BuildingMasterDTO modelDTO);
        Task<BuildingMasterDTO> GetByIdAsync(long Id);
        Task<BuildingMasterDTO> DeleteAsync(long Id);
    }
}
