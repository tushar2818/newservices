using AutoMapper;
using CityService.DATA;
using CityService.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CityService.BAL
{
    public class BusTypeMasterRepository : BaseRepository, IBusTypeMasterRepository
    {
        public BusTypeMasterRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public object Delete(long Id)
        {
            var model = this._dbContext.BusTypeMaster.Find(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            this._dbContext.SaveChanges();
            return model;
        }

        public object GetAll()
        {
            return this._dbContext.BusTypeMaster.Where(s => !s.IsDeleted &&
            s.CityId == Utility.GetStateId(this._dbContext, this.Request.applicationId)).OrderByDescending(s => s.Id).ToList();
        }

        public object GetById(long Id)
        {
            return this._dbContext.BusTypeMaster.Where(s => s.Id == Id && !s.IsDeleted &&
            s.CityId == Utility.GetStateId(this._dbContext, this.Request.applicationId)).ToList().FirstOrDefault();
        }

        public object SaveUpdate(BusTypeMasterDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            BusTypeMaster model = Mapper.Map<BusTypeMasterDTO, BusTypeMaster>(modelDTO);
            if (model.Id == 0)
            {
                model.CreatedDate = model.UpdatedDate;
                model.CityId = Utility.GetStateId(this._dbContext, this.Request.applicationId);
                this._dbContext.BusTypeMaster.Add(model);
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