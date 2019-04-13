using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public class BuildingMasterRepository : BaseRepository, IBuildingMasterRepository
    {
        LogType logType = LogType.CompanyMaster;
        public BuildingMasterRepository(ApplicationContext applicationContext) : 
            base(applicationContext)
        {
        }

        public async Task<BuildingMasterDTO> DeleteAsync(long Id)
        {
            var model = await this._dbContext.BuildingMaster.FindAsync(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
            var modelDTO = Mapper.Map<BuildingMaster, BuildingMasterDTO>(model);
            this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Delete);
            return modelDTO;
        }

        public async Task<IList<BuildingMasterDTO>> GetAllAsync()
        {
            var modelList = await this._dbContext.BuildingMaster.Where(s => !s.IsDeleted && s.IsActive
             && s.ProjectMasterID == this.Request.ProjectID ).ToListAsync();
            var modelDTOList = Mapper.Map<IList<BuildingMaster>, IList<BuildingMasterDTO>>(modelList);
            return modelDTOList;
        }

        public async Task<BuildingMasterDTO> GetByIdAsync(long Id)
        {
            var model = await this._dbContext.BuildingMaster.FindAsync(Id);
            var modelDTO = Mapper.Map<BuildingMaster, BuildingMasterDTO>(model);
            return modelDTO;
        }

        public async Task<BuildingMasterDTO> SaveUpdateAsync(BuildingMasterDTO modelDTO)
        {
            modelDTO.ProjectMasterID = this.Request.ProjectID;
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            var model = Mapper.Map<BuildingMasterDTO, BuildingMaster>(modelDTO);
            if (model.BuildingMasterID == 0)
            {
                model.CreatedDate = modelDTO.UpdatedDate;
                model.IsActive = true;
                await this._dbContext.BuildingMaster.AddAsync(model);
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Add);
            }
            else
            {
                this._dbContext.Entry(model).State = EntityState.Modified;
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Update);
            }
            modelDTO = Mapper.Map<BuildingMaster, BuildingMasterDTO>(model);
            return modelDTO;
        }
    } 
    
}
