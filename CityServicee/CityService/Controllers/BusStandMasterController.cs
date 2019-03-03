using System;
using System.Collections.Generic;
using CityService.BAL;
using CityService.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CityService.Controllers
{
    public class BusStandMasterController : BaseController
    {
        private IBusStandMasterRepository _repository;
        public BusStandMasterController(IBusStandMasterRepository repository)
        {
            _repository = repository;
        }
        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            base.OnActionExecuting(ctx);
            _repository.Request = (RequestDTO)this._request;
        }
        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Returns all bus stand names available for particular city
        /// </summary>
        /// <returns>Bus Stands</returns>
        [HttpGet]
        [Route("api/busstandmaster/getall")] 
        public object GetAll()
        {
            try
            {
                var data = _repository.GetAll(); 
                _response.Result = data;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<ErrorMessageDTO>() { new ErrorMessageDTO() { Message = ex.ToString() } };
            }
            return _response;
        }

        /// <summary>
        /// Returns bus stand details from bus stand id
        /// </summary>
        /// <param name="id">Bus stand id</param>
        /// <returns>Bus stand Details</returns>
        [HttpGet]
        [Route("api/busstandmaster/getbyid/{id}")]
        public object GetById(long id)
        {
            try
            {
                var data = _repository.GetById(id);
                _response.Result = data;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<ErrorMessageDTO>() { new ErrorMessageDTO() { Message = ex.ToString() } };
            }
            return _response;
        }

        /// <summary>
        /// Add/Update bus stand
        /// </summary>
        /// <param name="model">Bus stand details</param>
        /// <returns>Added/Updated bus stand details</returns>
        [HttpPost]
        [Route("api/busstandmaster/saveupdate")]
        public object Post([FromBody]BusStandMasterDTO model)
        {
            try
            {
                var data = _repository.SaveUpdate(model);
                _response.Result = data;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<ErrorMessageDTO>() { new ErrorMessageDTO() { Message = ex.ToString() } };
            }
            return _response;
        }

        /// <summary>
        /// Delete bus stand details
        /// </summary>
        /// <param name="id">Bus stand id</param>
        /// <returns>Deleted bus stand details</returns>
        [HttpDelete]
        [Route("api/busstandmaster/{id}")]  
        public object Delete(long id)
        {
            try
            {
                var data = _repository.Delete(id);
                _response.Result = data;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<ErrorMessageDTO>() { new ErrorMessageDTO() { Message = ex.ToString() } };
            }
            return _response;
        }
    }
}
