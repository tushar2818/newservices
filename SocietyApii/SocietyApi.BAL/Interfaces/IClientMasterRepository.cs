using SocietyApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface IClientMasterRepository : IBaseRepository
    {
        Task<IList<ClientMasterDTO>> GetAllAsync();
        Task<ClientMasterDTO> SaveUpdateAsync(ClientMasterDTO modelDTO);
        Task<ClientMasterDTO> GetByIdAsync(long Id);
        Task<ClientMasterDTO> DeleteAsync(long Id);
    }
}
