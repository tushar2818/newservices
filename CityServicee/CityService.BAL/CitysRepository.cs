using AutoMapper;
using CityService.DATA;
using CityService.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CityService.BAL
{
    public class CitysRepository : BaseRepository, ICitysRepository
    {
        public CitysRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
        
        public object GetAll()
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            using (var con = new SqlConnection(_dbContext.Database.GetDbConnection().ConnectionString))
            {
                con.Open();
                cmd = new SqlCommand("sp_ManageCitys", con);
                cmd.Parameters.Add(new SqlParameter("@Type", "GetAll"));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);

                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            return Converters.ConvertToDataTable(ds.Tables[0]);
        }

        public object GetById(long Id, bool isdetailsview)
        {
            if (!isdetailsview)
            {
                var model = this._dbContext.Citys.Where(s => s.Id == Id).FirstOrDefault();
                CitysDTO modelDTO = Mapper.Map<Citys, CitysDTO>(model);
                return modelDTO;
            }
            else
            {
                var model = this._dbContext.Citys.Where(s => s.Id == Id).FirstOrDefault();
                Dictionary<string, object> details = new Dictionary<string, object>();
                string stateName = " - ", districtName = " - ", talukaName = " - ";

                if (model.StateId.HasValue)
                    stateName = this._dbContext.Citys.Where(s => s.Id == model.StateId.Value).FirstOrDefault()?.CityName;
                if (model.DistrictId.HasValue)
                    districtName = this._dbContext.Citys.Where(s => s.Id == model.DistrictId.Value).FirstOrDefault()?.CityName;
                if (model.TalukaId.HasValue)
                    talukaName = this._dbContext.Citys.Where(s => s.Id == model.TalukaId.Value).FirstOrDefault()?.CityName;

                details.Add("City", model.CityName);
                details.Add("City OL", model.CityNameInOL);

                details.Add("City Type", Converters.GetCityTypeFromId(model.CityType));
                details.Add("State", stateName);

                details.Add("District", districtName);
                details.Add("Taluka", talukaName);

                details.Add("PinCode", model.PinCode);
                details.Add("Station Code", model.StationCode);

                details.Add("Latitude", model.Latitude);
                details.Add("Longitude", model.Longitude);

                details.Add("Male Population", model.MPopulation);
                details.Add("Female Population", model.FPopulation);

                details.Add("For Flex", model.ForFlex);
                details.Add("For PlaceBio", model.ForPlaceBio);

                details.Add("Created Date", model.CreatedDate);
                details.Add("Updated Date", model.UpdatedDate);

                details.Add("Active", model.IsActive);
                details.Add("Deleted", model.IsDeleted);

                return details;
            }
        }

        public object SaveUpdate(CitysDTO modelDTO)
        {
            modelDTO.UpdatedDate = Converters.GetCurrentEpochTime();
            Citys model = Mapper.Map<CitysDTO, Citys>(modelDTO);
            if (model.Id == 0)
            {
                model.CreatedDate = modelDTO.UpdatedDate;
                this._dbContext.Citys.Add(model);
                this._dbContext.SaveChanges();
            }
            else
            {
                this._dbContext.Entry(model).State = EntityState.Modified;
                this._dbContext.SaveChanges();
            }
            modelDTO = Mapper.Map<Citys, CitysDTO>(model);
            return model;
        }

        public object Delete(long Id)
        {
            var model = this._dbContext.Citys.Find(Id);
            model.IsDeleted = true;
            model.UpdatedDate = Converters.GetCurrentEpochTime();
            this._dbContext.Entry(model).State = EntityState.Modified;
            this._dbContext.SaveChanges();
            return model;

            //insert/update using stored procedure
            //var TypePara = new SqlParameter("@Type", "All");
            //var ApplicationIdPara = new SqlParameter("@ApplicationId", ApplicationId);
            ////return _dbContext.Citys.FromSql("sp_GetCitys @Type, @ApplicationId", TypePara, ApplicationIdPara); 
            //return _dbContext.RawDataTrain.FromSql("sp_GetCitys @Type, @ApplicationId", TypePara, ApplicationIdPara);
        }
    }
}