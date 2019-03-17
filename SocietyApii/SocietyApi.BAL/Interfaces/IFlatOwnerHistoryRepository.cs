using SocietyApi.DTO;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface IFlatOwnerHistoryRepository : IBaseRepository
    {
        Task<object> GetAllAsync();
        Task<object> SaveUpdateAsync(FlatOwnerHistoryDTO modelDTO);
        Task<object> GetByIdAsync(long Id);
        Task<object> DeleteAsync(long Id);
    }
}
