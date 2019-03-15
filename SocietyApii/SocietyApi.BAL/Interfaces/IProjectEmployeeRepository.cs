using SocietyApi.DTO;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface IProjectEmployeeRepository : IBaseRepository
    {
        Task<object> GetAllAsync();
        Task<object> SaveUpdateAsync(ProjectEmployeeDTO modelDTO);
        Task<object> GetByIdAsync(long Id);
        Task<object> DeleteAsync(long Id);
    }
}
