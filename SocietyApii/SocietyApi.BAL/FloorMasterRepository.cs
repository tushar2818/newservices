using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public class FloorMasterRepository : BaseRepository, IFloorMasterRepository
    {
        LogType logType = LogType.FloorMaster;

        public FloorMasterRepository(ApplicationContext applicationContext) : 
            base(applicationContext)
        {
        }

        public async Task<object> DeleteAsync(long Id)
        {
            var model = await this._dbContext.FloorMaster.FindAsync(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
            var modelDTO = Mapper.Map<FloorMaster, FloorMasterDTO>(model);
            this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Delete);
            return modelDTO;
        }

        public async Task<object> GetAllAsync()
        {
            //try
            //{
            //    await this._dbContext.Database.EnsureCreatedAsync();
            //}
            //catch (System.Exception ex )
            //{
            //}
            var modelList = await this._dbContext.FloorMaster.Where(s => !s.IsDeleted && s.IsActive).ToListAsync();
            var modelDTOList = Mapper.Map<IEnumerable<FloorMaster>, IEnumerable<FloorMasterDTO>>(modelList);
            return modelDTOList;
        }

        public async Task<object> GetByIdAsync(long Id)
        {
            var model = await this._dbContext.FloorMaster.FindAsync(Id); 
            var modelDTO = Mapper.Map<FloorMaster, FloorMasterDTO>(model);
            return modelDTO;
        }

        public async Task<object> SaveUpdateAsync(FloorMasterDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            var model = Mapper.Map<FloorMasterDTO, FloorMaster>(modelDTO);
            if (model.FloorMasterID == 0)
            {
                model.CreatedDate = modelDTO.UpdatedDate;
                model.IsActive = true;
                await this._dbContext.FloorMaster.AddAsync(model);
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Add);
            }
            else
            {
                this._dbContext.Entry(model).State = EntityState.Modified;
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Update);
            }
            modelDTO = Mapper.Map<FloorMaster, FloorMasterDTO>(model);
            return modelDTO;
        }
    }
}
