using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public class FlatOwnerHistoryRepository : BaseRepository, IFlatOwnerHistoryRepository
    {
        LogType logType = LogType.FlatOwnerHistory;
        public FlatOwnerHistoryRepository(ApplicationContext applicationContext) :
            base(applicationContext)
        {
        }

        public async Task<object> DeleteAsync(long Id)
        {
            var model = await this._dbContext.FlatOwnerHistory.FindAsync(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
            var modelDTO = Mapper.Map<FlatOwnerHistory, FlatOwnerHistoryDTO>(model);
            this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Delete);
            return modelDTO;
        }

        public async Task<object> GetAllAsync()
        {
            var modelList = await this._dbContext.FlatOwnerHistory.Where(s => !s.IsDeleted && s.IsActive).ToListAsync();
            var modelDTOList = Mapper.Map<IEnumerable<FlatOwnerHistory>, IEnumerable<FlatOwnerHistoryDTO>>(modelList);
            return modelDTOList;
        }

        public async Task<object> GetByIdAsync(long Id)
        {
            var model = await this._dbContext.FlatOwnerHistory.FindAsync(Id);
            var modelDTO = Mapper.Map<FlatOwnerHistory, FlatOwnerHistoryDTO>(model);
            return modelDTO;
        }

        public async Task<object> SaveUpdateAsync(FlatOwnerHistoryDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            var model = Mapper.Map<FlatOwnerHistoryDTO, FlatOwnerHistory>(modelDTO);
            if (model.FlatOwnerHistoryID == 0)
            {
                model.CreatedDate = modelDTO.UpdatedDate;
                model.IsActive = true;
                await this._dbContext.FlatOwnerHistory.AddAsync(model);
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Add);
            }
            else
            {
                this._dbContext.Entry(model).State = EntityState.Modified;
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Update);
            }
            modelDTO = Mapper.Map<FlatOwnerHistory, FlatOwnerHistoryDTO>(model);
            return modelDTO;
        }
    }
}
