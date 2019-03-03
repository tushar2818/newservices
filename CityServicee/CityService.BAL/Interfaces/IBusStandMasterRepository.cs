using CityService.DTO; 

namespace CityService.BAL
{
    public interface IBusStandMasterRepository : IBaseRepository
    {
        object GetAll();
        object GetById(long Id);
        object SaveUpdate(BusStandMasterDTO modelDTO);
        object Delete(long Id);
    }
}
