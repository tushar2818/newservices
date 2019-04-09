using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public class PersonMasterRepository : BaseRepository, IPersonMasterRepository
    {
        LogType logType = LogType.PersonMaster;
        public PersonMasterRepository(ApplicationContext applicationContext) : 
            base(applicationContext)
        {
        }

        public async Task<PersonMasterDTO> DeleteAsync(long Id)
        {
            var model = await this._dbContext.PersonMaster.FindAsync(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
            var modelDTO = Mapper.Map<PersonMaster, PersonMasterDTO>(model);
            this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Delete);
            return modelDTO;
        }

        public async Task<IList<PersonMasterDTO>> GetAllAsync()
        {
            var modelList = await this._dbContext.PersonMaster.Where(s => !s.IsDeleted && s.IsActive).ToListAsync();
            var modelDTOList = Mapper.Map<IList<PersonMaster>, IList<PersonMasterDTO>>(modelList);
            return modelDTOList;
        }

        public async Task<PersonMasterDTO> GetByIdAsync(long Id)
        {
            var model = await this._dbContext.PersonMaster.FindAsync(Id);
            var modelDTO = Mapper.Map<PersonMaster, PersonMasterDTO>(model);
            return modelDTO;
        }

        public async Task<PersonMasterDTO> SaveUpdateAsync(PersonMasterDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            var model = Mapper.Map<PersonMasterDTO, PersonMaster>(modelDTO);
            if (model.PersonMasterID == 0)
            {
                model.CreatedDate = modelDTO.UpdatedDate;
                model.IsActive = true;
                await this._dbContext.PersonMaster.AddAsync(model);
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Add);
            }
            else
            {
                this._dbContext.Entry(model).State = EntityState.Modified;
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Update);
            }
            modelDTO = Mapper.Map<PersonMaster, PersonMasterDTO>(model);
            return modelDTO;
        }
    } 
    
}
