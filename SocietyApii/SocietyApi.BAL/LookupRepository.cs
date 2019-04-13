using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyApi.BAL
{
    public class LookupRepository : BaseRepository, ILookupRepository
    {
        IDesignationTypeRepository designationTypeRepository;
        IDesignationMasterRepository designationMasterRepository;
        IDesignationTypeMappingRepository designationTypeMappingRepository;
        IPersonMasterRepository personMasterRepository;

        public LookupRepository(ApplicationContext applicationContext,
            IDesignationTypeRepository designationTypeRepository,
            IDesignationMasterRepository designationMasterRepository,
            IDesignationTypeMappingRepository designationTypeMappingRepository,
            IPersonMasterRepository personMasterRepository) : base(applicationContext)
        {
            this.designationTypeRepository = designationTypeRepository;
            this.designationMasterRepository = designationMasterRepository;
            this.designationTypeMappingRepository = designationTypeMappingRepository;
            this.personMasterRepository = personMasterRepository;
        }

        public async Task<IList<LookupDetailDTO>> GetLookups(IList<LookupDetailDTO> modelList)
        {
            foreach (var item in modelList)
            {
                try
                {
                    item.IsSuccess = true;
                    dynamic result = null;

                    switch (item.LookupType)
                    {
                        //get all designation types
                        case "AllDesignationTypes":
                            var allDesignationTypes = await this.designationTypeRepository.GetAllAsync();
                            result = allDesignationTypes.Select(s => new { s.DesignationTypeID, s.DesignationTypeValue }).OrderBy(s => s.DesignationTypeValue);
                            break;

                        //get all designations 
                        case "AllDesignations":
                            var allDesignations = await this.designationMasterRepository.GetAllAsync();
                            result = allDesignations.Select(s => new { s.DesignationMasterID, s.DesignationValue }).OrderBy(s => s.DesignationValue);
                            break;

                        //get all designations type mapping
                        case "AllDesignationTypesMappings":

                            var allDesignationsTypeMapping = await this.designationTypeMappingRepository.GetAllAsync();

                            var group = allDesignationsTypeMapping.GroupBy(s => s.DesignationTypeID);

                            IList<ParentChildIdDTO> designationTypeMaping = new List<ParentChildIdDTO>();

                            foreach (var mapping in group)
                            {
                                designationTypeMaping.Add(new ParentChildIdDTO()
                                {
                                    ParentID = mapping.Key,
                                    ChildID = mapping.ToList().Select(s => s.DesignationMasterID).ToList()
                                });
                            }
                            result = designationTypeMaping;
                            break;

                        //get all clients 
                        case "LoggedInUserDetails":

                            IList<CommonDesignationDTO> commonDesignationsList=null;
                            IList<CompanyMasterDTO> allCompaniesList=null;
                            IList<ProjectMasterDTO> allProjectList=null;

                            //get user designation details
                            try
                            {
                                var userDetails = item.Parameters.FirstOrDefault(s => s.Key == "UserID");
                                var commonDesignations = await this._dbContext.CommonDesignation.Include(s => s.PersonMaster)
                                        .Include(s => s.CommonTableType).Include(s => s.DesignationMaster).
                                        Where(s => s.PersonMaster.UserID.Equals(userDetails.Value)
                                           && s.PersonID.Equals(s.PersonMaster.PersonMasterID)
                                           && !s.IsDeleted && !s.PersonMaster.IsDeleted).ToListAsync();
                                commonDesignationsList = Mapper.Map<IList<CommonDesignation>, IList<CommonDesignationDTO>>(commonDesignations);
                            }
                            catch (Exception)
                            {
                            }

                            //get company list according to user
                            try
                            {
                                var clientId = commonDesignationsList.First().PersonMaster.ClientMasterID;
                                var allCompanies = await this._dbContext.CompanyMaster.Where(s => s.ClientMasterID.Equals(
                                clientId) && !s.IsDeleted).OrderBy(s => s.CompanyName).ToListAsync();
                                allCompaniesList = Mapper.Map<IList<CompanyMaster>, IList<CompanyMasterDTO>>(allCompanies);
                            }
                            catch (Exception)
                            {
                            }

                            //get project list according to user 
                            try
                            {
                                var companyId = allCompaniesList.First().CompanyMasterID;
                                var allProjects = await this._dbContext.ProjectMaster.Where(s => s.CompanyMasterID == companyId
                                && !s.IsDeleted).OrderBy(s=>s.ProjectName).ToListAsync();
                                allProjectList = Mapper.Map<IList<ProjectMaster>, IList<ProjectMasterDTO>>(allProjects);
                            }
                            catch (Exception)
                            {
                            }

                            //combine all result
                            result = new { DesignationList= commonDesignationsList,
                                CompaniesList = allCompaniesList,
                                ProjectList = allProjectList
                            };
                            break;

                        //get all designations 
                        case "AllBuildings":
                            var allBuildings = await this._dbContext.BuildingMaster.Where(s => !s.IsDeleted
                            && s.ProjectMasterID == this.Request.ProjectID).ToListAsync();
                            result = allBuildings.Select(s => new { s.BuildingMasterID, s.BuildingName }).
                                OrderBy(s => s.BuildingName);
                            break;

                        default:
                            break;
                    }
                    item.Data = result;
                }
                catch (System.Exception ex)
                {
                    item.IsSuccess = false;
                    item.ErrorMessages = new List<ErrorMessageDTO>() { new ErrorMessageDTO() { Message = ex.ToString() } };
                } 
            }
            return modelList;
        }
    }
}
