using SocietyApi.DTO;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface ISocietyMasterRepository : IBaseRepository
    {
        Task<object> GetAllAsync();
        Task<object> SaveUpdateAsync(SocietyMasterDTO modelDTO);
        Task<object> GetByIdAsync(long Id);
        Task<object> DeleteAsync(long Id);
    }
}
