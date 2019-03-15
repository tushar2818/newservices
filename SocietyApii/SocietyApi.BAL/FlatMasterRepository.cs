using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public class FlatMasterRepository : BaseRepository, IFlatMasterRepository
    {
        LogType logType = LogType.FlatMaster;
        public FlatMasterRepository(ApplicationContext applicationContext) :
            base(applicationContext)
        {
        }

        public async Task<object> DeleteAsync(long Id)
        {
            var model = await this._dbContext.FlatMaster.FindAsync(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
            var modelDTO = Mapper.Map<FlatMaster, FlatMasterDTO>(model);
            this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Delete);
            return modelDTO;
        }

        public async Task<object> GetAllAsync()
        {
            var modelList = await this._dbContext.FlatMaster.Where(s => !s.IsDeleted && s.IsActive).ToListAsync();
            var modelDTOList = Mapper.Map<IEnumerable<FlatMaster>, IEnumerable<FlatMasterDTO>>(modelList);
            return modelList;
        }

        public async Task<object> GetByIdAsync(long Id)
        {
            var model = await this._dbContext.FlatMaster.FindAsync(Id);
            var modelDTO = Mapper.Map<FlatMaster, FlatMasterDTO>(model);
            return modelDTO;
        }

        public async Task<object> SaveUpdateAsync(FlatMasterDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            var model = Mapper.Map<FlatMasterDTO, FlatMaster>(modelDTO);
            if (model.FlatMasterID == 0)
            {
                model.CreatedDate = modelDTO.UpdatedDate;
                await this._dbContext.FlatMaster.AddAsync(model);
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Add);
            }
            else
            {
                this._dbContext.Entry(model).State = EntityState.Modified;
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Update);
            }
            modelDTO = Mapper.Map<FlatMaster, FlatMasterDTO>(model);
            return model;
        }
    }
}
