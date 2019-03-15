using SocietyApi.DTO;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface IDesignationMasterRepository : IBaseRepository
    {
        Task<object> GetAllAsync();
        Task<object> SaveUpdateAsync(DesignationMasterDTO modelDTO);
        Task<object> GetByIdAsync(long Id);
        Task<object> DeleteAsync(long Id);
    }
}
