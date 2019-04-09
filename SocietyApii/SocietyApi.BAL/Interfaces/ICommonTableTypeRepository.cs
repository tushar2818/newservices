using SocietyApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface ICommonTableTypeRepository : IBaseRepository
    {
        Task<IList<CommonTableTypeDTO>> GetAllAsync();
        Task<CommonTableTypeDTO> SaveUpdateAsync(CommonTableTypeDTO modelDTO);
        Task<CommonTableTypeDTO> GetByIdAsync(long Id);
        Task<CommonTableTypeDTO> DeleteAsync(long Id);
    }
}
