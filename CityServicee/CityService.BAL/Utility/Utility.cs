using CityService.DATA;
using System.Linq;

namespace CityService.BAL
{
    public class Utility
    {
        public static long GetStateId(ApplicationContext applicationContext, long id)
        {
            if (id == 0) return id;
            var model = applicationContext.Citys.Where(s => s.Id == id).FirstOrDefault();
            return model.StateId.HasValue ? model.StateId.Value : id;
        }
    } 
}
