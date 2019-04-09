using SocietyApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface IProjectMasterRepository : IBaseRepository
    {
        Task<IList<ProjectMasterDTO>> GetAllAsync();
        Task<ProjectMasterDTO> SaveUpdateAsync(ProjectMasterDTO modelDTO);
        Task<ProjectMasterDTO> GetByIdAsync(long Id);
        Task<ProjectMasterDTO> DeleteAsync(long Id);
    }
}
