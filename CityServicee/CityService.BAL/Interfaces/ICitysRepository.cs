using CityService.DTO;

namespace CityService.BAL
{
    public interface ICitysRepository : IBaseRepository
    {
        object GetAll();
        object SaveUpdate(CitysDTO modelDTO);
        object GetById(long Id, bool isSaveUpdate);
        object Delete(long Id);
    }
}
