using System;
using System.Collections.Generic;
using CityService.BAL;
using CityService.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CityService.Controllers
{
    public class BusTimeTableController : BaseController
    {
        private IBusTimeTableRepository _repository;
        public BusTimeTableController(IBusTimeTableRepository repository)
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
        /// Returns all bus time table available for particular city
        /// </summary>
        /// <returns>Bus time table</returns>
        [HttpGet]
        [Route("api/bustimetable/getall")]
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
        /// Returns bus time table details from id
        /// </summary>
        /// <param name="id">Bus time table id</param>
        /// <param name="isdetailsview">Get details for detail view</param>
        /// <returns>Bus time table details</returns>
        [HttpGet]
        [Route("api/bustimetable/getbyid/{id}/{isdetailsview}")]
        public object GetById(long id, bool isdetailsview = false)
        {
            try
            {
                var data = _repository.GetById(id, isdetailsview);
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
        /// Add/Update bus time table
        /// </summary>
        /// <param name="model">bus time table details</param>
        /// <returns>Added/Updated bus time table details</returns>
        [HttpPost]
        [Route("api/bustimetable/saveupdate")]
        public object Post([FromBody]BusTimeTableDTO model)
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
        /// Delete bus time table details
        /// </summary>
        /// <param name="id">bus time table id</param>
        /// <returns>Deleted bus time table details</returns>
        [HttpDelete]
        [Route("api/bustimetable/{id}")]
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