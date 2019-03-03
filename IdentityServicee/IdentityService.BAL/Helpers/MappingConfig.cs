
namespace IdentityService.BAL
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMissingTypeMaps = true;
                //config.CreateMap<Citys, CitysDTO>();
            });
        }
    }
}
