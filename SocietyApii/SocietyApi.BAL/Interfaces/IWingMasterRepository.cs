using SocietyApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface IWingMasterRepository : IBaseRepository
    {
        Task<IList<WingMasterDTO>> GetAllAsync();
        Task<WingMasterDTO> SaveUpdateAsync(WingMasterDTO modelDTO);
        Task<WingMasterDTO> GetByIdAsync(long Id);
        Task<WingMasterDTO> DeleteAsync(long Id);
    }
}
