using SocietyApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface IDesignationMasterRepository : IBaseRepository
    {
        Task<IList<DesignationMasterDTO>> GetAllAsync();
        Task<DesignationMasterDTO> SaveUpdateAsync(DesignationMasterDTO modelDTO);
        Task<DesignationMasterDTO> GetByIdAsync(long Id);
        Task<DesignationMasterDTO> DeleteAsync(long Id);
    }
}
