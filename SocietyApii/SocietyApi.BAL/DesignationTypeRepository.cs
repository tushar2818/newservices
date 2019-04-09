using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public class DesignationTypeRepository : BaseRepository, IDesignationTypeRepository
    {
        LogType logType = LogType.DesignationType;
        public DesignationTypeRepository(ApplicationContext applicationContext) : 
            base(applicationContext)
        {
        }

        public async Task<DesignationTypeDTO> DeleteAsync(long Id)
        {
            var model = await this._dbContext.DesignationType.FindAsync(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
            var modelDTO = Mapper.Map<DesignationType, DesignationTypeDTO>(model);
            this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Delete);
            return modelDTO;
        }

        public async Task<IList<DesignationTypeDTO>> GetAllAsync()
        {
            var modelList = await this._dbContext.DesignationType.Where(s => !s.IsDeleted && s.IsActive).ToListAsync();
            var modelDTOList = Mapper.Map<IList<DesignationType>, IList<DesignationTypeDTO>>(modelList);
            return modelDTOList;
        }

        public async Task<DesignationTypeDTO> GetByIdAsync(long Id)
        {
            var model = await this._dbContext.DesignationType.FindAsync(Id);
            var modelDTO = Mapper.Map<DesignationType, DesignationTypeDTO>(model);
            return modelDTO;
        }

        public async Task<DesignationTypeDTO> SaveUpdateAsync(DesignationTypeDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            var model = Mapper.Map<DesignationTypeDTO, DesignationType>(modelDTO);
            if (model.DesignationTypeID == 0)
            {
                model.CreatedDate = modelDTO.UpdatedDate;
                model.IsActive = true;
                await this._dbContext.DesignationType.AddAsync(model);
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Add);
            }
            else
            {
                this._dbContext.Entry(model).State = EntityState.Modified;
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Update);
            }
            modelDTO = Mapper.Map<DesignationType, DesignationTypeDTO>(model);
            return modelDTO;
        }
    } 
    
}
