using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocietyApi.BAL;
using SocietyApi.DTO;

namespace SocietyApi.Controllers
{
    public class LookupController : BaseController
    {
        private ILookupRepository repository;
        public LookupController(ILookupRepository repository)
        {
            this.repository = repository;
        }
        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            base.OnActionExecuting(ctx);
            repository.Request = (RequestDTO)this._request;
        }
        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }


        /// <summary>
        /// Method used to get lookup data from lookup keys
        /// </summary>
        /// <param name="model">Lookup keys details</param>
        /// <returns>Returns lookup data from lookup keys</returns>
        [HttpPost]
        [Route("api/lookup/getlookups")]
        public async Task<object> Post([FromBody]IList<LookupDetailDTO> model)
        {
            try
            {
                var data = await repository.GetLookups(model);
                _response.Result = data;
                _response.IsSuccess = repository.IsSuccess;
                _response.ErrorMessages = repository.ErrorMessages;
                _response.DisplayMessage = repository.DisplayMessage;
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
