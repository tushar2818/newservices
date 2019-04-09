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

        public async Task<FlatMasterDTO> DeleteAsync(long Id)
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

        public async Task<IList<FlatMasterDTO>> GetAllAsync()
        {
            var modelList = await this._dbContext.FlatMaster.Where(s => !s.IsDeleted && s.IsActive).ToListAsync();
            var modelDTOList = Mapper.Map<IList<FlatMaster>, IList<FlatMasterDTO>>(modelList);
            return modelDTOList;
        }

        public async Task<FlatMasterDTO> GetByIdAsync(long Id)
        {
            var model = await this._dbContext.FlatMaster.FindAsync(Id);
            var modelDTO = Mapper.Map<FlatMaster, FlatMasterDTO>(model);
            return modelDTO;
        }

        public async Task<FlatMasterDTO> SaveUpdateAsync(FlatMasterDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            var model = Mapper.Map<FlatMasterDTO, FlatMaster>(modelDTO);
            if (model.FlatMasterID == 0)
            {
                model.CreatedDate = modelDTO.UpdatedDate;
                model.IsActive = true;
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
            return modelDTO;
        }
    }
}
