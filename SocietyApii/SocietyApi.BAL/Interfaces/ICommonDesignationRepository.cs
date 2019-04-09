using SocietyApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface ICommonDesignationRepository : IBaseRepository
    {
        Task<IList<CommonDesignationDTO>> GetAllAsync();
        Task<CommonDesignationDTO> SaveUpdateAsync(CommonDesignationDTO modelDTO);
        Task<CommonDesignationDTO> GetByIdAsync(long Id);
        Task<CommonDesignationDTO> DeleteAsync(long Id);
    }
}
