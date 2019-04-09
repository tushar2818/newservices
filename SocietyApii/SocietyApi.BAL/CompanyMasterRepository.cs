using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public class CompanyMasterRepository : BaseRepository, ICompanyMasterRepository
    {
        LogType logType = LogType.CompanyMaster;
        public CompanyMasterRepository(ApplicationContext applicationContext) : 
            base(applicationContext)
        {
        }

        public async Task<CompanyMasterDTO> DeleteAsync(long Id)
        {
            var model = await this._dbContext.CompanyMaster.FindAsync(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
            var modelDTO = Mapper.Map<CompanyMaster, CompanyMasterDTO>(model);
            this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Delete);
            return modelDTO;
        }

        public async Task<IList<CompanyMasterDTO>> GetAllAsync()
        {
            var modelList = await this._dbContext.CompanyMaster.Where(s => !s.IsDeleted && s.IsActive).ToListAsync();
            var modelDTOList = Mapper.Map<IList<CompanyMaster>, IList<CompanyMasterDTO>>(modelList);
            return modelDTOList;
        }

        public async Task<CompanyMasterDTO> GetByIdAsync(long Id)
        {
            var model = await this._dbContext.CompanyMaster.FindAsync(Id);
            var modelDTO = Mapper.Map<CompanyMaster, CompanyMasterDTO>(model);
            return modelDTO;
        }

        public async Task<CompanyMasterDTO> SaveUpdateAsync(CompanyMasterDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            var model = Mapper.Map<CompanyMasterDTO, CompanyMaster>(modelDTO);
            if (model.CompanyMasterID == 0)
            {
                model.CreatedDate = modelDTO.UpdatedDate;
                model.IsActive = true;
                await this._dbContext.CompanyMaster.AddAsync(model);
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Add);
            }
            else
            {
                this._dbContext.Entry(model).State = EntityState.Modified;
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Update);
            }
            modelDTO = Mapper.Map<CompanyMaster, CompanyMasterDTO>(model);
            return modelDTO;
        }
    } 
    
}
