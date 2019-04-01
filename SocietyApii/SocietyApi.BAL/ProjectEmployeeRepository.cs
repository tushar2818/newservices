using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public class ProjectEmployeeRepository : BaseRepository, IProjectEmployeeRepository
    {
        LogType logType = LogType.ProjectEmployee;
        public ProjectEmployeeRepository(ApplicationContext applicationContext) :
            base(applicationContext)
        {
        }

        public async Task<object> DeleteAsync(long Id)
        {
            return null;
            //var model = await this._dbContext.ProjectEmployee.FindAsync(Id);
            //model.IsDeleted = true;
            //model.UpdatedDate = Converters.GetCurrentEpochTime();
            //this._dbContext.Entry(model).State = EntityState.Modified;
            //await this._dbContext.SaveChangesAsync();
            //var modelDTO = Mapper.Map<ProjectEmployee, ProjectEmployeeDTO>(model);
            //this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Delete);
            //return modelDTO;
        }

        public async Task<object> GetAllAsync()
        {
            return null;
            //var modelList = await this._dbContext.ProjectEmployee.Where(s => !s.IsDeleted && s.IsActive).ToListAsync();
            //var modelDTOList = Mapper.Map<IEnumerable<ProjectEmployee>, IEnumerable<ProjectEmployeeDTO>>(modelList);
            //return modelDTOList;
        }

        public async Task<object> GetByIdAsync(long Id)
        {
            return null;
            //var model = await this._dbContext.ProjectEmployee.FindAsync(Id);
            //var modelDTO = Mapper.Map<ProjectEmployee, ProjectEmployeeDTO>(model);
            //return modelDTO;
        }

        public async Task<object> SaveUpdateAsync(ProjectEmployeeDTO modelDTO)
        {
            return null;
            //modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            //var model = Mapper.Map<ProjectEmployeeDTO, ProjectEmployee>(modelDTO);
            //if (model.ProjectEmployeeID == 0)
            //{
            //    model.CreatedDate = modelDTO.UpdatedDate;
            //    model.IsActive = true;
            //    await this._dbContext.ProjectEmployee.AddAsync(model);
            //    await this._dbContext.SaveChangesAsync();
            //    this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Add);
            //}
            //else
            //{
            //    this._dbContext.Entry(model).State = EntityState.Modified;
            //    await this._dbContext.SaveChangesAsync();
            //    this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Update);
            //}
            //modelDTO = Mapper.Map<ProjectEmployee, ProjectEmployeeDTO>(model);
            //return modelDTO;
        }
    }
}
