using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public class CommonDesignationRepository : BaseRepository, ICommonDesignationRepository
    {
        LogType logType = LogType.CommonDesignation;
        public CommonDesignationRepository(ApplicationContext applicationContext) : 
            base(applicationContext)
        {
        }

        public async Task<CommonDesignationDTO> DeleteAsync(long Id)
        {
            var model = await this._dbContext.CommonDesignation.FindAsync(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
            var modelDTO = Mapper.Map<CommonDesignation, CommonDesignationDTO>(model);
            this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Delete);
            return modelDTO;
        }

        public async Task<IList<CommonDesignationDTO>> GetAllAsync()
        {
            var modelList = await this._dbContext.CommonDesignation.Where(s => !s.IsDeleted && s.IsActive).ToListAsync();
            var modelDTOList = Mapper.Map<IList<CommonDesignation>, IList<CommonDesignationDTO>>(modelList);
            return modelDTOList;
        }

        public async Task<CommonDesignationDTO> GetByIdAsync(long Id)
        {
            var model = await this._dbContext.CommonDesignation.FindAsync(Id);
            var modelDTO = Mapper.Map<CommonDesignation, CommonDesignationDTO>(model);
            return modelDTO;
        }

        public async Task<CommonDesignationDTO> SaveUpdateAsync(CommonDesignationDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            var model = Mapper.Map<CommonDesignationDTO, CommonDesignation>(modelDTO);
            if (model.CommonDesignationID == 0)
            {
                model.CreatedDate = modelDTO.UpdatedDate;
                model.IsActive = true;
                await this._dbContext.CommonDesignation.AddAsync(model);
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Add);
            }
            else
            {
                this._dbContext.Entry(model).State = EntityState.Modified;
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Update);
            }
            modelDTO = Mapper.Map<CommonDesignation, CommonDesignationDTO>(model);
            return modelDTO;
        }
    } 
    
}
