using CityService.DATA;
using CityService.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CityService.BAL
{
    public class LookupRepository : BaseRepository, ILookupRepository
    {
        public LookupRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public object GetLookups(List<LookupDetail> lookupDetails)
        {
            Dictionary<LookupType, object> lookupList = new Dictionary<LookupType, object>();
            foreach (var lookupDetail in lookupDetails)
            {
                object result = null;
                switch (lookupDetail.LookupType)
                {
                    case LookupType.CityForPlaceBio:
                        result = from model in this._dbContext.Citys.OrderBy(s=>s.CityName)
                                 where !model.IsDeleted && model.ForPlaceBio
                                 select new { Key = model.Id, Value = model.CityName, ValueInOL = model.CityNameInOL };
                        break;
                    case LookupType.CityAll:
                        result = from model in this._dbContext.Citys.OrderBy(s => s.CityName)
                                 where !model.IsDeleted
                                 select new { Key = model.Id, Value = model.CityName, ValueInOL = model.CityNameInOL };
                        break;
                    case LookupType.BusTypes:
                        result = from model in this._dbContext.BusTypeMaster.OrderBy(s => s.BusType)
                                 where !model.IsDeleted && model.CityId == Utility.GetStateId(this._dbContext, this.Request.applicationId)
                                 select new { Key = model.Id, Value = model.BusType, ValueInOL = model.BusTypeInOL };
                        break;
                    case LookupType.BusStands:
                        result = from model in this._dbContext.BusStandMaster.OrderBy(s => s.StandName)
                                 where !model.IsDeleted && model.CityId == this.Request.applicationId
                                 select new { Key = model.Id, Value = model.StandName, ValueInOL = model.StandNameInOL };
                        break;
                    default:
                        break;
                }
                lookupList.Add(lookupDetail.LookupType, result);
            }
            return lookupList;
        }
    }
}
