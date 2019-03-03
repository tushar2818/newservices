using System;
using System.Collections.Generic;
using CityService.BAL;
using CityService.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CityService.Controllers
{
    public class CitysController : BaseController
    {
        private ICitysRepository _ICitysRepository;
        public CitysController(ICitysRepository citysRepository)
        {
            _ICitysRepository = citysRepository;
        }
        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            base.OnActionExecuting(ctx);
            _ICitysRepository.Request = (RequestDTO)this._request;
        }
        protected override void Dispose(bool disposing)
        {
            _ICitysRepository.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Returns all citys  
        /// </summary>
        /// <returns>All citys</returns>
        [HttpGet]
        [Route("api/city/getall")]
        public object GetAll()
        {
            try
            {
                var data = _ICitysRepository.GetAll();
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
        /// Get city details from city id and purpose
        /// </summary>
        /// <param name="id">City Id</param>
        /// <param name="isdetailsview">Purpose</param>
        /// <returns>City Details</returns>
        [HttpGet]
        [Route("api/city/getbyid/{id}/{isdetailsview}")]
        public object GetById(long id, bool isdetailsview)
        {
            try
            {
                var data = _ICitysRepository.GetById(id, isdetailsview);
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
        /// Save/Update city details
        /// </summary>
        /// <param name="model">City details</param>
        /// <returns>Added/Updated city details</returns>
        [HttpPost]
        [Route("api/city/saveupdate")]
        public object Post([FromBody]CitysDTO model)
        {
            try
            {
                var data = _ICitysRepository.SaveUpdate(model);
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
        /// Method used to delete city
        /// </summary>
        /// <param name="id">City Id</param>
        /// <returns>Deleted city details</returns>
        [HttpDelete]
        [Route("api/city/{id}")]
        public object Delete(long id)
        {
            try
            {
                var data = _ICitysRepository.Delete(id);
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
