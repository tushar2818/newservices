
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
                //config.CreateMap<CompanyMaster, CompanyMasterDTO>();
                //config.CreateMap<DesignationMaster, DesignationMasterDTO>();
                //config.CreateMap<EmployeeMaster, EmployeeMasterDTO>();
                //config.CreateMap<FlatMaster, FlatMasterDTO>();
                //config.CreateMap<FlatTypeMaster, FlatTypeMasterDTO>();
                //config.CreateMap<FloorMaster, FloorMasterDTO>();
                //config.CreateMap<ProjectEmployee, ProjectEmployeeDTO>();
                //config.CreateMap<ProjectMaster, ProjectMasterDTO>();
                //config.CreateMap<WingMaster, WingMasterDTO>();
            });
        }
    }
}
