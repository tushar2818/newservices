using AutoMapper;
using CityService.DATA;
using CityService.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CityService.BAL
{
    public class BusTimeTableRepository : BaseRepository, IBusTimeTableRepository
    {
        public BusTimeTableRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public object Delete(long Id)
        {
            var model = this._dbContext.BusTimeTable.Find(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            this._dbContext.SaveChanges();
            return model;
        }

        public object GetAll()
        {
            return this._dbContext.BusTimeTable.Where(s => !s.IsDeleted && s.CityId == this.Request.applicationId).
                Include(s => s.Citys).Include(s => s.BusStandMaster).Include(s => s.BusTypeMaster).Include(s => s.SourceCitys).
                Include(s => s.DestinationCitys).OrderByDescending(s => s.Id).ToList();
        }

        public object GetById(long Id, bool IsDetailsView = false)
        {
            if (!IsDetailsView)
            {
                var model = this._dbContext.BusTimeTable.Where(s => s.Id == Id).FirstOrDefault();
                BusTimeTableDTO modelDTO = Mapper.Map<BusTimeTable, BusTimeTableDTO>(model);
                return modelDTO;
            }
            else
            {
                var result = this._dbContext.BusTimeTable.Where(s => s.Id == Id).
                      Include(s => s.Citys).Include(s => s.BusStandMaster).Include(s => s.BusTypeMaster).Include(s => s.SourceCitys).
                      Include(s => s.DestinationCitys).ToList().FirstOrDefault();
                Dictionary<string, object> details = new Dictionary<string, object>();
                details.Add("Source", result.SourceCitys.CityName);
                details.Add("Source OL", result.SourceCitys.CityNameInOL);
                details.Add("Destination", result.DestinationCitys.CityName);
                details.Add("Destination OL", result.DestinationCitys.CityNameInOL);
                details.Add("Via", result.Via);
                details.Add("Via OL", result.ViaInOL);
                details.Add("Times", result.Times);
                details.Add("Times OL", result.TimesInOL);
                details.Add("Created Date", Converters.epoch2string(result.CreatedDate));
                details.Add("Updated Date", Converters.epoch2string(result.UpdatedDate));
                details.Add("Active", result.IsActive);
                return details;
            }
        }

        public object SaveUpdate(BusTimeTableDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            BusTimeTable model = Mapper.Map<BusTimeTableDTO, BusTimeTable>(modelDTO);
            if (model.Id == 0)
            {
                model.CreatedDate = model.UpdatedDate;
                model.CityId = this.Request.applicationId;
                this._dbContext.BusTimeTable.Add(model);
                this._dbContext.SaveChanges();
            }
            else
            {
                this._dbContext.Entry(model).State = EntityState.Modified;
                this._dbContext.SaveChanges();
            }
            return model;
        }
    }
}