using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public class DesignationTypeMappingRepository : BaseRepository, IDesignationTypeMappingRepository
    {
        LogType logType = LogType.DesignationTypeMapping;
        public DesignationTypeMappingRepository(ApplicationContext applicationContext) : 
            base(applicationContext)
        {
        }

        public async Task<DesignationTypeMappingDTO> DeleteAsync(long Id)
        {
            var model = await this._dbContext.DesignationTypeMapping.FindAsync(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
            var modelDTO = Mapper.Map<DesignationTypeMapping, DesignationTypeMappingDTO>(model);
            this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Delete);
            return modelDTO;
        }

        public async Task<IList<DesignationTypeMappingDTO>> GetAllAsync()
        {
            var modelList = await this._dbContext.DesignationTypeMapping.Where(s => !s.IsDeleted && s.IsActive).ToListAsync();
            var modelDTOList = Mapper.Map<IList<DesignationTypeMapping>, IList<DesignationTypeMappingDTO>>(modelList);
            return modelDTOList;
        }

        public async Task<DesignationTypeMappingDTO> GetByIdAsync(long Id)
        {
            var model = await this._dbContext.DesignationTypeMapping.FindAsync(Id);
            var modelDTO = Mapper.Map<DesignationTypeMapping, DesignationTypeMappingDTO>(model);
            return modelDTO;
        }       

        public async Task<DesignationTypeMappingDTO> SaveUpdateAsync(DesignationTypeMappingDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            var model = Mapper.Map<DesignationTypeMappingDTO, DesignationTypeMapping>(modelDTO);
            if (model.DesignationTypeMappingID == 0)
            {
                model.CreatedDate = modelDTO.UpdatedDate;
                model.IsActive = true;
                await this._dbContext.DesignationTypeMapping.AddAsync(model);
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Add);
            }
            else
            {
                this._dbContext.Entry(model).State = EntityState.Modified;
                await this._dbContext.SaveChangesAsync();
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Update);
            }
            modelDTO = Mapper.Map<DesignationTypeMapping, DesignationTypeMappingDTO>(model);
            return modelDTO;
        }

        public async Task<ParentChildIdDTO> MapDesignationsType(ParentChildIdDTO parentChildIdDTO)
        {
            var updatedDate = Converters.GetCurrentEpochTime();

            //delete all existing records
            var allExistingRecords = await this._dbContext.DesignationTypeMapping.Where(s => s.DesignationTypeID == 
            parentChildIdDTO.ParentID).ToListAsync();
            if (allExistingRecords.Any())
            {
                allExistingRecords.ForEach(a => { a.IsDeleted = true; a.UpdatedDate = updatedDate; });
                await this._dbContext.SaveChangesAsync();
            }

            //add or update new records
            allExistingRecords = await this._dbContext.DesignationTypeMapping.Where(s =>
            s.DesignationTypeID == parentChildIdDTO.ParentID).ToListAsync();
            foreach (var item in parentChildIdDTO.ChildID)
            {
                var existingRecord = allExistingRecords.SingleOrDefault(s => 
                s.DesignationTypeID == parentChildIdDTO.ParentID && s.DesignationMasterID == item);
                if (existingRecord == null)
                {
                    //add records
                    await this.SaveUpdateAsync(new DesignationTypeMappingDTO()
                    {
                        DesignationTypeID = parentChildIdDTO.ParentID,
                        DesignationMasterID = item
                    });
                }
                else
                {
                    //update existing records
                    existingRecord.IsDeleted = false;
                    existingRecord.UpdatedDate = updatedDate;
                    this._dbContext.Entry(existingRecord).State = EntityState.Modified;
                    await this._dbContext.SaveChangesAsync();
                }
            }
            this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Add);
            return parentChildIdDTO; 
        }

        public async Task<IList<ParentChildIdDTO>> MapDesignationsTypes(IList<ParentChildIdDTO> parentChildIdDTOs)
        {
            foreach (var item in parentChildIdDTOs)
                await this.MapDesignationsType(item);
            return parentChildIdDTOs;
        }
    } 
}
