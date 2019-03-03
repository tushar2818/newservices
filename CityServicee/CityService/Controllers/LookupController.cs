using System;
using System.Collections.Generic;
using CityService.BAL;
using CityService.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CityService.Controllers
{
    public class LookupController : BaseController
    {
        private ILookupRepository _repository;
        public LookupController(ILookupRepository repository)
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
        /// Returns lookups
        /// </summary>
        /// <returns>Bus time table</returns>
        [HttpPost]
        [Route("api/lookup/getall")]
        public object GetById([FromBody]List<LookupDetail> lookupDetails)
        {
            try
            {
                var data = _repository.GetLookups(lookupDetails);
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