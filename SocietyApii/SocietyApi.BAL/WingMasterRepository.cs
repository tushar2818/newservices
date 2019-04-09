using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public class WingMasterRepository : BaseRepository, IWingMasterRepository
    {
        LogType logType = LogType.WingMaster;
        public WingMasterRepository(ApplicationContext applicationContext) :
            base(applicationContext)
        {
        }

        public async Task<WingMasterDTO> DeleteAsync(long Id)
        {
            var model = await this._dbContext.WingMaster.FindAsync(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
            var modelDTO = Mapper.Map<WingMaster, WingMasterDTO>(model);
            this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Delete);
            return modelDTO;
        }

        public async Task<IList<WingMasterDTO>> GetAllAsync()
        {
            var modelList = await this._dbContext.WingMaster.Where(s => !s.IsDeleted && s.IsActive).ToListAsync();
            var modelDTOList = Mapper.Map<IList<WingMaster>, IList<WingMasterDTO>>(modelList);
            return modelDTOList;
        }

        public async Task<WingMasterDTO> GetByIdAsync(long Id)
        {
            var model = await this._dbContext.WingMaster.FindAsync(Id);
            var modelDTO = Mapper.Map<WingMaster, WingMasterDTO>(model);
            return modelDTO;
        }

        public async Task<WingMasterDTO> SaveUpdateAsync(WingMasterDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            var model = Mapper.Map<WingMasterDTO, WingMaster>(modelDTO);
            if (model.WingMasterID == 0)
            {
                model.CreatedDate = modelDTO.UpdatedDate;
                model.IsActive = true;
                await this._dbContext.WingMaster.AddAsync(model);
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Add);
            }
            else
            {
                this._dbContext.Entry(model).State = EntityState.Modified;
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Update);
            }
            modelDTO = Mapper.Map<WingMaster, WingMasterDTO>(model);
            return modelDTO;
        }
    }
}
