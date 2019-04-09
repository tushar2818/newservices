
using SocietyApi.DATA;
using SocietyApi.DTO;

namespace SocietyApi.BAL
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMissingTypeMaps = true;
                config.CreateMap<BuildingMaster, BuildingMasterDTO>();
                config.CreateMap<ClientMaster, ClientMasterDTO>();
                config.CreateMap<CommonDesignation, CommonDesignationDTO>();
                config.CreateMap<CommonTableType, CommonTableTypeDTO>();
                config.CreateMap<CompanyMaster, CompanyMasterDTO>();
                config.CreateMap<DesignationMaster, DesignationMasterDTO>();
                config.CreateMap<DesignationType, DesignationTypeDTO>();
                config.CreateMap<DesignationTypeMapping, DesignationTypeMappingDTO>();
                config.CreateMap<FloorMaster, FloorMasterDTO>();
                config.CreateMap<FlatTypeMaster, FlatTypeMasterDTO>();
                config.CreateMap<FloorMaster, FloorMasterDTO>();
                config.CreateMap<PersonMaster, PersonMasterDTO>();
                config.CreateMap<ProjectMaster, ProjectMasterDTO>();
                config.CreateMap<WingMaster, WingMasterDTO>();
            });
        }
    }
}
