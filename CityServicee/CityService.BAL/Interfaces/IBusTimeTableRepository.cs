using CityService.DTO;

namespace CityService.BAL
{
    public interface IBusTimeTableRepository : IBaseRepository
    {
        object GetAll();
        object GetById(long Id, bool IsDetailsView = false);
        object SaveUpdate(BusTimeTableDTO modelDTO);
        object Delete(long Id);
    }
}
