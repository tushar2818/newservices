using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public class DesignationMasterRepository : BaseRepository, IDesignationMasterRepository
    {
        LogType logType = LogType.DesignationMaster;
        public DesignationMasterRepository(ApplicationContext applicationContext) :
            base(applicationContext)
        {
        }

        public async Task<object> DeleteAsync(long Id)
        {
            var model = await this._dbContext.DesignationMaster.FindAsync(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
            var modelDTO = Mapper.Map<DesignationMaster, DesignationMasterDTO>(model);
            this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Delete);
            return modelDTO;
        }

        public async Task<object> GetAllAsync()
        {
            var modelList = await this._dbContext.DesignationMaster.Where(s => !s.IsDeleted && s.IsActive).ToListAsync();
            var modelDTOList = Mapper.Map<IEnumerable<DesignationMaster>, IEnumerable<DesignationMasterDTO>>(modelList);
            return modelDTOList;
        }

        public async Task<object> GetByIdAsync(long Id)
        {
            var model = await this._dbContext.DesignationMaster.FindAsync(Id);
            var modelDTO = Mapper.Map<DesignationMaster, DesignationMasterDTO>(model);
            return modelDTO;
        }

        public async Task<object> SaveUpdateAsync(DesignationMasterDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            var model = Mapper.Map<DesignationMasterDTO, DesignationMaster>(modelDTO);
            if (model.DesignationMasterID == 0)
            {
                model.CreatedDate = modelDTO.UpdatedDate;
                model.IsActive = true;
                await this._dbContext.DesignationMaster.AddAsync(model);
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Add);
            }
            else
            {
                this._dbContext.Entry(model).State = EntityState.Modified;
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Update);
            }
            modelDTO = Mapper.Map<DesignationMaster, DesignationMasterDTO>(model);
            return modelDTO;
        }
    }
}
