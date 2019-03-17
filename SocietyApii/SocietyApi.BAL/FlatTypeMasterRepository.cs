using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public class FlatTypeMasterRepository : BaseRepository, IFlatTypeMasterRepository
    {
        LogType logType = LogType.FlatTypeMaster;
        public FlatTypeMasterRepository(ApplicationContext applicationContext) :
            base(applicationContext)
        {
        }

        public async Task<object> DeleteAsync(long Id)
        {
            var model = await this._dbContext.FlatTypeMaster.FindAsync(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
            var modelDTO = Mapper.Map<FlatTypeMaster, FlatTypeMasterDTO>(model);
            this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Delete);
            return modelDTO;
        }

        public async Task<object> GetAllAsync()
        {
            var modelList = await this._dbContext.FlatTypeMaster.Where(s => !s.IsDeleted && s.IsActive).ToListAsync();
            var modelDTOList = Mapper.Map<IEnumerable<FlatTypeMaster>, IEnumerable<FlatTypeMasterDTO>>(modelList);
            return modelDTOList;
        }

        public async Task<object> GetByIdAsync(long Id)
        {
            var model = await this._dbContext.FlatTypeMaster.FindAsync(Id);
            var modelDTO = Mapper.Map<FlatTypeMaster, FlatTypeMasterDTO>(model);
            return modelDTO;
        }

        public async Task<object> SaveUpdateAsync(FlatTypeMasterDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            var model = Mapper.Map<FlatTypeMasterDTO, FlatTypeMaster>(modelDTO);
            if (model.FlatTypeMasterID == 0)
            {
                model.CreatedDate = modelDTO.UpdatedDate;
                model.IsActive = true;
                await this._dbContext.FlatTypeMaster.AddAsync(model);
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Add);
            }
            else
            {
                this._dbContext.Entry(model).State = EntityState.Modified;
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Update);
            }
            modelDTO = Mapper.Map<FlatTypeMaster, FlatTypeMasterDTO>(model);
            return modelDTO;
        }
    }
}
