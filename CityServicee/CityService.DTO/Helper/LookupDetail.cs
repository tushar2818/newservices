using System.Collections.Generic;

namespace CityService.DTO
{
    public class LookupDetail
    {
        public LookupType LookupType { get; set; }
        public Dictionary<LookupParameter, object> Parameters { get; set; }
    }
}
