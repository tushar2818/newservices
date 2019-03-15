using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocietyApi.BAL;
using SocietyApi.DTO;

namespace SocietyApi.Controllers
{
    public class DesignationMasterController : BaseController
    {
        private IDesignationMasterRepository repository;
        public DesignationMasterController(IDesignationMasterRepository repository)
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
        /// Returns all designation masters 
        /// </summary>
        /// <returns>All designation masters</returns>
        [HttpGet]
        [Route("api/designationmaster/getall")]
        public async Task<object> GetAll()
        {
            try
            {
                var data = await repository.GetAllAsync();
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
        /// Get designation master details from designation master id
        /// </summary>
        /// <param name="id">designation master Id</param>
        /// <returns>designation master details</returns>
        [HttpGet]
        [Route("api/designationmaster/getbyid/{id}")]
        public async Task<object> GetById(long id)
        {
            try
            {
                var data = await repository.GetByIdAsync(id);
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
        /// Save/Update designation master details
        /// </summary>
        /// <param name="model">designation master details</param>
        /// <returns>Added/Updated designation master details</returns>
        [HttpPost]
        [Route("api/designationmaster/saveupdate")]
        public async Task<object> Post([FromBody]DesignationMasterDTO model)
        {
            try
            {
                var data = await repository.SaveUpdateAsync(model);
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

        /// <summary>
        /// Method used to delete designation master
        /// </summary>
        /// <param name="id">designation master Id</param>
        /// <returns>Deleted designation master details</returns>
        [HttpDelete]
        [Route("api/designationmaster/{id}")]
        public async Task<object> Delete(long id)
        {
            try
            {
                var data = await repository.DeleteAsync(id);
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
