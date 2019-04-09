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
        public ICommonTableTypeRepository commonTableTypeRepository { get; set; }
        public IDesignationTypeRepository designationTypeRepository { get; set; }
        public IDesignationMasterRepository designationMasterRepository { get; set; }

        public FloorMasterRepository(ApplicationContext applicationContext,
            ICommonTableTypeRepository commonTableTypeRepository,
            IDesignationTypeRepository designationTypeRepository,
            IDesignationMasterRepository designationMasterRepository) : 
            base(applicationContext)
        {
            this.commonTableTypeRepository = commonTableTypeRepository;
            this.designationTypeRepository = designationTypeRepository;
            this.designationMasterRepository = designationMasterRepository;
        }

        public async Task<object> CreateDatabaseAsync()
        {
            //create database
            var status = await this._dbContext.Database.EnsureCreatedAsync();

            //create common table type
            await this.commonTableTypeRepository.SaveUpdateAsync(new CommonTableTypeDTO() { CommonTableTypeKey = "BuildingMaster", CommonTableTypeValue = "Building Master" });
            await this.commonTableTypeRepository.SaveUpdateAsync(new CommonTableTypeDTO() { CommonTableTypeKey = "ClientMaster", CommonTableTypeValue = "Client Master" });
            await this.commonTableTypeRepository.SaveUpdateAsync(new CommonTableTypeDTO() { CommonTableTypeKey = "CompanyMaster", CommonTableTypeValue = "Company Master" });
            await this.commonTableTypeRepository.SaveUpdateAsync(new CommonTableTypeDTO() { CommonTableTypeKey = "FlatMaster", CommonTableTypeValue = "Flat Master" });
            await this.commonTableTypeRepository.SaveUpdateAsync(new CommonTableTypeDTO() { CommonTableTypeKey = "GateMaster", CommonTableTypeValue = "Gate Master" });
            await this.commonTableTypeRepository.SaveUpdateAsync(new CommonTableTypeDTO() { CommonTableTypeKey = "PersonMaster", CommonTableTypeValue = "Person Master" });
            await this.commonTableTypeRepository.SaveUpdateAsync(new CommonTableTypeDTO() { CommonTableTypeKey = "ProjectMaster", CommonTableTypeValue = "Project Master" });
            await this.commonTableTypeRepository.SaveUpdateAsync(new CommonTableTypeDTO() { CommonTableTypeKey = "WingMaster", CommonTableTypeValue = "Wing Master" });
            await this.commonTableTypeRepository.SaveUpdateAsync(new CommonTableTypeDTO() { CommonTableTypeKey = "ComplaintMaster", CommonTableTypeValue = "Complaint Master" });

            //create designation type
            await this.designationTypeRepository.SaveUpdateAsync(new DesignationTypeDTO() { DesignationTypeKey = "ClientDesignation", DesignationTypeValue = "Client Designation" });
            await this.designationTypeRepository.SaveUpdateAsync(new DesignationTypeDTO() { DesignationTypeKey = "CompanyDesignation", DesignationTypeValue = "Company Designation" });
            await this.designationTypeRepository.SaveUpdateAsync(new DesignationTypeDTO() { DesignationTypeKey = "ProjectDesignation", DesignationTypeValue = "Project Designation" });
            await this.designationTypeRepository.SaveUpdateAsync(new DesignationTypeDTO() { DesignationTypeKey = "BuildingDesignation", DesignationTypeValue = "Building Designation" });
            await this.designationTypeRepository.SaveUpdateAsync(new DesignationTypeDTO() { DesignationTypeKey = "WingDesignation", DesignationTypeValue = "Wing Designation" });
            await this.designationTypeRepository.SaveUpdateAsync(new DesignationTypeDTO() { DesignationTypeKey = "GateDesignation", DesignationTypeValue = "Gate Designation" });
            await this.designationTypeRepository.SaveUpdateAsync(new DesignationTypeDTO() { DesignationTypeKey = "FlatDesignation", DesignationTypeValue = "Flat Designation" });

            //create designations
            await this.designationMasterRepository.SaveUpdateAsync(new DesignationMasterDTO() { DesignationKey = "ClientAdmin", DesignationValue = "Client Admin", DesignationMar = "Client Admin", DesignationHin = "Client Admin" });
            await this.designationMasterRepository.SaveUpdateAsync(new DesignationMasterDTO() { DesignationKey = "CompanyAdmin", DesignationValue = "Company Admin", DesignationMar = "Company Admin", DesignationHin = "Company Admin" });
            await this.designationMasterRepository.SaveUpdateAsync(new DesignationMasterDTO() { DesignationKey = "ProjectAdmin", DesignationValue = "Project Admin", DesignationMar = "Project Admin", DesignationHin = "Project Admin" });
            await this.designationMasterRepository.SaveUpdateAsync(new DesignationMasterDTO() { DesignationKey = "BuildingAdmin", DesignationValue = "Building Admin", DesignationMar = "Building Admin", DesignationHin = "Building Admin" });
            await this.designationMasterRepository.SaveUpdateAsync(new DesignationMasterDTO() { DesignationKey = "WingAdmin", DesignationValue = "Wing Admin", DesignationMar = "Wing Admin", DesignationHin = "Wing Admin" });
            await this.designationMasterRepository.SaveUpdateAsync(new DesignationMasterDTO() { DesignationKey = "FlatOwner", DesignationValue = "Flat Owner", DesignationMar = "Flat Owner", DesignationHin = "Flat Owner" });
            await this.designationMasterRepository.SaveUpdateAsync(new DesignationMasterDTO() { DesignationKey = "FlatTenant", DesignationValue = "Flat Tenant", DesignationMar = "Flat Tenant", DesignationHin = "Flat Tenant" });
            await this.designationMasterRepository.SaveUpdateAsync(new DesignationMasterDTO() { DesignationKey = "FlatMember", DesignationValue = "Flat Member", DesignationMar = "Flat Member", DesignationHin = "Flat Member" });
            await this.designationMasterRepository.SaveUpdateAsync(new DesignationMasterDTO() { DesignationKey = "FlatGuest", DesignationValue = "Flat Guest", DesignationMar = "Flat Guest", DesignationHin = "Flat Guest" });

            this.DisplayMessage = "Database created successfully";
            return true;
        }

        public async Task<FloorMasterDTO> DeleteAsync(long Id)
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

        public async Task<IList<FloorMasterDTO>> GetAllAsync()
        {           
            var modelList = await this._dbContext.FloorMaster.Where(s => !s.IsDeleted && s.IsActive).ToListAsync();
            var modelDTOList = Mapper.Map<IList<FloorMaster>, IList<FloorMasterDTO>>(modelList);
            return modelDTOList;
        }

        public async Task<FloorMasterDTO> GetByIdAsync(long Id)
        {
            var model = await this._dbContext.FloorMaster.FindAsync(Id); 
            var modelDTO = Mapper.Map<FloorMaster, FloorMasterDTO>(model);
            return modelDTO;
        }

        public async Task<FloorMasterDTO> SaveUpdateAsync(FloorMasterDTO modelDTO)
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
