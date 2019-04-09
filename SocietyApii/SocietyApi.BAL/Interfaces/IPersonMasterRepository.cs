using SocietyApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface IPersonMasterRepository : IBaseRepository
    {
        Task<IList<PersonMasterDTO>> GetAllAsync();
        Task<PersonMasterDTO> SaveUpdateAsync(PersonMasterDTO modelDTO);
        Task<PersonMasterDTO> GetByIdAsync(long Id);
        Task<PersonMasterDTO> DeleteAsync(long Id);
    }
}
