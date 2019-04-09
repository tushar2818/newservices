using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public class ClientMasterRepository : BaseRepository, IClientMasterRepository
    {
        LogType logType = LogType.ClientMaster;
        public ClientMasterRepository(ApplicationContext applicationContext) :
            base(applicationContext)
        {
        }

        public async Task<ClientMasterDTO> DeleteAsync(long Id)
        {
            var model = await this._dbContext.ClientMaster.FindAsync(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
            var modelDTO = Mapper.Map<ClientMaster, ClientMasterDTO>(model);
            this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Delete);
            return modelDTO;
        }

        public async Task<IList<ClientMasterDTO>> GetAllAsync()
        {
            var modelList = await this._dbContext.ClientMaster.ToListAsync();
            var modelDTOList = Mapper.Map<IList<ClientMaster>, IList<ClientMasterDTO>>(modelList);
            return modelDTOList;
        }

        public async Task<ClientMasterDTO> GetByIdAsync(long Id)
        {
            var model = await this._dbContext.ClientMaster.FindAsync(Id);
            var modelDTO = Mapper.Map<ClientMaster, ClientMasterDTO>(model);

            //get first name and last name
            var personMaster = await this._dbContext.PersonMaster.FirstOrDefaultAsync(s => s.UserID == modelDTO.UserID);
            if (personMaster != null)
            {
                modelDTO.FirstName = personMaster.FirstName;
                modelDTO.LastName = personMaster.LastName;
            }
            return modelDTO;
        }

        public async Task<ClientMasterDTO> SaveUpdateAsync(ClientMasterDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            var model = Mapper.Map<ClientMasterDTO, ClientMaster>(modelDTO);

            //check prerequsite
            var designationModel = await this._dbContext.DesignationMaster.
                FirstOrDefaultAsync(s => s.DesignationKey == Constants.DesignationMasterClientAdmin);
            var commonTableTypeModel = await this._dbContext.CommonTableType.
                FirstOrDefaultAsync(s => s.CommonTableTypeKey == Constants.CommonTableTypeClientMaster);

            if (model.ClientMasterID == 0)
            {                
                if (designationModel == null || commonTableTypeModel == null)
                {
                    this.IsSuccess = false;
                    this.ErrorMessages = new List<ErrorMessageDTO>() {
                        new ErrorMessageDTO(){ Message= @"No required record found. Please make sure that you added 'Client Admin' designation and 'ClientMaster' key " }
                    };
                }
                else
                {
                    //add client master
                    //add in client master table
                    model.CreatedDate = modelDTO.UpdatedDate;
                    model.IsActive = true;
                    await this._dbContext.ClientMaster.AddAsync(model);
                    await this._dbContext.SaveChangesAsync();

                    //add in person table
                    var personMaster = new PersonMaster()
                    {
                        ClientMasterID = model.ClientMasterID,
                        UserID = model.UserID,
                        FirstName = modelDTO.FirstName,
                        LastName = modelDTO.LastName,
                        Email = model.Email,
                        MobileNo = model.Mobile,
                        IsActive = true,
                        CreatedDate = model.CreatedDate,
                        UpdatedDate = model.UpdatedDate
                    };
                    await this._dbContext.PersonMaster.AddAsync(personMaster);
                    await this._dbContext.SaveChangesAsync();

                    //add in common designation table
                    var commonDesignation = new CommonDesignation()
                    {
                        CommonTableTypeID = commonTableTypeModel.CommonTableTypeID,
                        SourceID = model.ClientMasterID,
                        PersonID = personMaster.PersonMasterID,
                        DesignationMasterID = designationModel.DesignationMasterID,
                        FromDate = model.VallidFrom,
                        ToDate = model.VallidTill,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedDate = model.CreatedDate,
                        UpdatedDate = model.CreatedDate
                    };
                    await this._dbContext.CommonDesignation.AddAsync(commonDesignation);
                    await this._dbContext.SaveChangesAsync();
                    this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Add);
                }
            }
            else
            {
                //update in client master
                this._dbContext.Entry(model).State = EntityState.Modified;
                await this._dbContext.SaveChangesAsync();

                //update in person master
                var personMaster = await this._dbContext.PersonMaster.FirstOrDefaultAsync(s => s.UserID == modelDTO.UserID);
                if (personMaster != null)
                {
                    personMaster.FirstName = modelDTO.FirstName;
                    personMaster.LastName = modelDTO.LastName;
                    personMaster.Email = model.Email;
                    personMaster.MobileNo = model.Mobile;
                    personMaster.IsActive = model.IsActive;
                    personMaster.IsDeleted = model.IsDeleted;
                    personMaster.CreatedDate = model.CreatedDate;
                    personMaster.UpdatedDate = model.UpdatedDate;
                    this._dbContext.Entry(personMaster).State = EntityState.Modified;
                    await this._dbContext.SaveChangesAsync();
                }

                //update in common designation
                var commonDesignation = await this._dbContext.CommonDesignation.FirstOrDefaultAsync
                    (s => s.SourceID == model.ClientMasterID && s.CommonTableTypeID == commonTableTypeModel.CommonTableTypeID);
                if (commonDesignation != null)
                {
                    commonDesignation.FromDate = model.VallidFrom;
                    commonDesignation.ToDate = model.VallidTill;
                    commonDesignation.IsActive = model.IsActive;
                    commonDesignation.IsDeleted = model.IsDeleted;
                    commonDesignation.CreatedDate = model.CreatedDate;
                    commonDesignation.UpdatedDate = model.CreatedDate;
                    this._dbContext.Entry(personMaster).State = EntityState.Modified;
                    await this._dbContext.SaveChangesAsync();
                }
                this.DisplayMessage = CommonMethods.GetMessage(this.logType, LogAction.Update);
            }
            modelDTO = Mapper.Map<ClientMaster, ClientMasterDTO>(model);
            return modelDTO;
        }
    }
}
