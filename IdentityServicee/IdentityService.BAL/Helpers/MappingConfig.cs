
using IdentityService.DATA;
using IdentityService.DTO;

namespace IdentityService.BAL
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMissingTypeMaps = true;
                config.AllowNullCollections = true;
                config.AllowNullDestinationValues = true;
                config.CreateMap<ApplicationUser, ApplicationUserDTO>();
                config.CreateMap<ApplicationRole, ApplicationRoleDTO>();
            });
        }
    }
}
