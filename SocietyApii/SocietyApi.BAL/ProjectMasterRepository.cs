using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public class ProjectMasterRepository : BaseRepository, IProjectMasterRepository
    {
        LogType logType = LogType.ProjectMaster;
        public ProjectMasterRepository(ApplicationContext applicationContext) :
            base(applicationContext)
        {
        }

        public async Task<ProjectMasterDTO> DeleteAsync(long Id)
        {
            var model = await this._dbContext.ProjectMaster.FindAsync(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
            var modelDTO = Mapper.Map<ProjectMaster, ProjectMasterDTO>(model);
            this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Delete);
            return modelDTO;
        }

        public async Task<IList<ProjectMasterDTO>> GetAllAsync()
        {
            var modelList = await this._dbContext.ProjectMaster.Where(s => !s.IsDeleted && s.IsActive).ToListAsync();
            var modelDTOList = Mapper.Map<IList<ProjectMaster>, IList<ProjectMasterDTO>>(modelList);
            return modelDTOList;
        }

        public async Task<ProjectMasterDTO> GetByIdAsync(long Id)
        {
            var model = await this._dbContext.ProjectMaster.FindAsync(Id);
            var modelDTO = Mapper.Map<ProjectMaster, ProjectMasterDTO>(model);
            return modelDTO;
        }

        public async Task<ProjectMasterDTO> SaveUpdateAsync(ProjectMasterDTO modelDTO)
        {
            modelDTO.CompanyMasterID = this.Request.CompanyID;
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            var model = Mapper.Map<ProjectMasterDTO, ProjectMaster>(modelDTO);
            if (model.ProjectMasterID == 0)
            {
                model.CreatedDate = modelDTO.UpdatedDate;
                model.IsActive = true;
                await this._dbContext.ProjectMaster.AddAsync(model);
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Add);
            }
            else
            {
                this._dbContext.Entry(model).State = EntityState.Modified;
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Update);
            }
            modelDTO = Mapper.Map<ProjectMaster, ProjectMasterDTO>(model);
            return modelDTO;
        }
    }
}
