using SocietyApi.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface IDesignationTypeMappingRepository : IBaseRepository
    {
        Task<IList<DesignationTypeMappingDTO>> GetAllAsync();
        Task<DesignationTypeMappingDTO> SaveUpdateAsync(DesignationTypeMappingDTO modelDTO);
        Task<DesignationTypeMappingDTO> GetByIdAsync(long Id);
        Task<DesignationTypeMappingDTO> DeleteAsync(long Id);

        Task<ParentChildIdDTO> MapDesignationsType(ParentChildIdDTO parentChildIdDTO);
        Task<IList<ParentChildIdDTO>> MapDesignationsTypes(IList<ParentChildIdDTO> parentChildIdDTOs);
    }
}
