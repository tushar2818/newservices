using CityService.DTO;

namespace CityService.BAL
{
    public interface IBusTypeMasterRepository : IBaseRepository
    {
        object GetAll();
        object GetById(long Id);
        object SaveUpdate(BusTypeMasterDTO modelDTO);
        object Delete(long Id);
    }
}
