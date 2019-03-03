using AutoMapper;
using CityService.DATA;
using CityService.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CityService.BAL
{
    public class BusStandMasterRepository : BaseRepository, IBusStandMasterRepository
    {
        public BusStandMasterRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public object Delete(long Id)
        {
            var model = this._dbContext.BusStandMaster.Find(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            this._dbContext.SaveChanges();
            return model;
        }

        public object GetAll()
        {
            return this._dbContext.BusStandMaster.Where(s => !s.IsDeleted && s.CityId == this.Request.applicationId).
                OrderByDescending(s => s.Id).ToList();
        }

        public object GetById(long Id)
        {
            return this._dbContext.BusStandMaster.Where(s => !s.IsDeleted && s.CityId == this.Request.applicationId &&
            s.Id == Id).ToList().FirstOrDefault();
        }

        public object SaveUpdate(BusStandMasterDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            BusStandMaster model = Mapper.Map<BusStandMasterDTO, BusStandMaster>(modelDTO);
            if (model.Id == 0)
            {
                model.CreatedDate = model.UpdatedDate;
                model.CityId = this.Request.applicationId;
                this._dbContext.BusStandMaster.Add(model);
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
