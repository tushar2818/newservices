using SocietyApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface ICompanyMasterRepository : IBaseRepository
    {
        Task<IList<CompanyMasterDTO>> GetAllAsync();
        Task<CompanyMasterDTO> SaveUpdateAsync(CompanyMasterDTO modelDTO);
        Task<CompanyMasterDTO> GetByIdAsync(long Id);
        Task<CompanyMasterDTO> DeleteAsync(long Id);
    }
}
