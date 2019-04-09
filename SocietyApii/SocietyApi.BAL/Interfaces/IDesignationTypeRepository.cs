using SocietyApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface IDesignationTypeRepository : IBaseRepository
    {
        Task<IList<DesignationTypeDTO>> GetAllAsync();
        Task<DesignationTypeDTO> SaveUpdateAsync(DesignationTypeDTO modelDTO);
        Task<DesignationTypeDTO> GetByIdAsync(long Id);
        Task<DesignationTypeDTO> DeleteAsync(long Id);
    }
}
