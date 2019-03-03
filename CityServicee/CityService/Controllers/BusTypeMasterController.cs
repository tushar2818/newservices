using System;
using System.Collections.Generic;
using CityService.BAL;
using CityService.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CityService.Controllers
{
    public class BusTypeMasterController : BaseController
    {
        private IBusTypeMasterRepository _repository;
        public BusTypeMasterController(IBusTypeMasterRepository repository)
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
        /// Returns all bus types available for particular state
        /// </summary>
        /// <returns>Bus Types</returns>
        [HttpGet]
        [Route("api/bustypemaster/getall")] 
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
        /// Returns bus type details from bus type id
        /// </summary>
        /// <param name="id">Bus type id</param>
        /// <returns>Bus Type Details</returns>
        [HttpGet]
        [Route("api/bustypemaster/getbyid/{id}")]
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
        /// Add/Update bus stype
        /// </summary>
        /// <param name="model">Bus type details</param>
        /// <returns>Added/Updated bus type details</returns>
        [HttpPost]
        [Route("api/bustypemaster/saveupdate")]
        public object Post([FromBody]BusTypeMasterDTO model)
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
        /// Delete bus type details
        /// </summary>
        /// <param name="id">Bus type id</param>
        /// <returns>Deleted bus type details</returns>
        [HttpDelete]
        [Route("api/bustypemaster/{id}")]  
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
