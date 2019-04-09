using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public class CommonTableTypeRepository : BaseRepository, ICommonTableTypeRepository
    {
        LogType logType = LogType.CommonTableType;
        public CommonTableTypeRepository(ApplicationContext applicationContext) : 
            base(applicationContext)
        {
        }

        public async Task<CommonTableTypeDTO> DeleteAsync(long Id)
        {
            var model = await this._dbContext.CommonTableType.FindAsync(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
            var modelDTO = Mapper.Map<CommonTableType, CommonTableTypeDTO>(model);
            this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Delete);
            return modelDTO;
        }

        public async Task<IList<CommonTableTypeDTO>> GetAllAsync()
        {
            var modelList = await this._dbContext.CommonTableType.Where(s => !s.IsDeleted && s.IsActive).ToListAsync();
            var modelDTOList = Mapper.Map<IList<CommonTableType>, IList<CommonTableTypeDTO>>(modelList);
            return modelDTOList;
        }

        public async Task<CommonTableTypeDTO> GetByIdAsync(long Id)
        {
            var model = await this._dbContext.CommonTableType.FindAsync(Id);
            var modelDTO = Mapper.Map<CommonTableType, CommonTableTypeDTO>(model);
            return modelDTO;
        }

        public async Task<CommonTableTypeDTO> SaveUpdateAsync(CommonTableTypeDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            var model = Mapper.Map<CommonTableTypeDTO, CommonTableType>(modelDTO);
            if (model.CommonTableTypeID == 0)
            {
                model.CreatedDate = modelDTO.UpdatedDate;
                model.IsActive = true;
                await this._dbContext.CommonTableType.AddAsync(model);
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Add);
            }
            else
            {
                this._dbContext.Entry(model).State = EntityState.Modified;
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Update);
            }
            modelDTO = Mapper.Map<CommonTableType, CommonTableTypeDTO>(model);
            return modelDTO;
        }
    } 
    
}
