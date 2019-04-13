using SocietyApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public interface IWingMasterRepository : IBaseRepository
    {
        Task<IList<WingMasterDTO>> GetAllAsync(Int64 buildingMasterID);
        Task<WingMasterDTO> SaveUpdateAsync(WingMasterDTO modelDTO);
        Task<WingMasterDTO> GetByIdAsync(long Id);
        Task<WingMasterDTO> DeleteAsync(long Id);
    }
}
