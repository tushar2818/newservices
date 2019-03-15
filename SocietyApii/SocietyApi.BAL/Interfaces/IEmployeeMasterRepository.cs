using SocietyApi.DTO;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface IEmployeeMasterRepository : IBaseRepository
    {
        Task<object> GetAllAsync();
        Task<object> SaveUpdateAsync(EmployeeMasterDTO modelDTO);
        Task<object> GetByIdAsync(long Id);
        Task<object> DeleteAsync(long Id);
    }
}
