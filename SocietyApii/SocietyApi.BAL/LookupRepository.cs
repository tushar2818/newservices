using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocietyApi.DATA;
using SocietyApi.DTO;
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

        public LookupRepository(ApplicationContext applicationContext,
            IDesignationTypeRepository designationTypeRepository,
            IDesignationMasterRepository designationMasterRepository,
            IDesignationTypeMappingRepository designationTypeMappingRepository) : base(applicationContext)
        {
            this.designationTypeRepository = designationTypeRepository;
            this.designationMasterRepository = designationMasterRepository;
            this.designationTypeMappingRepository = designationTypeMappingRepository;
        }

        public async Task<IList<LookupDetailDTO>> GetLookups(IList<LookupDetailDTO> modelList)
        {
            foreach (var item in modelList)
            {
                object result = null;
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
                            designationTypeMaping.Add(new ParentChildIdDTO() {
                                ParentID = mapping.Key,
                                ChildID = mapping.ToList().Select(s=> s.DesignationMasterID).ToList()
                            });
                        }
                        result = designationTypeMaping;
                        break;
                    default:
                        break;
                }
                item.Data = result;
            }
            return modelList;
        }
    }
}
