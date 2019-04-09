using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocietyApi.BAL;
using SocietyApi.DTO;

namespace SocietyApi.Controllers
{
    public class DesignationTypeMappingController : BaseController
    {
        private IDesignationTypeMappingRepository repository;
        public DesignationTypeMappingController(IDesignationTypeMappingRepository repository)
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
        /// Returns all designation types mappings
        /// </summary>
        /// <returns>All designation type mappings</returns>
        [HttpGet]
        [Route("api/designationtypemapping/getall")]
        public async Task<object> GetAll()
        {
            try
            {
                var data = await repository.GetAllAsync();
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
        /// Get designation type mapping details from designation type mapping id
        /// </summary>
        /// <param name="id">designation type mapping Id</param>
        /// <returns>designation type mapping Details</returns>
        [HttpGet]
        [Route("api/designationtypemapping/getbyid/{id}")]
        public async Task<object> GetById(long id)
        {
            try
            {
                var data = await repository.GetByIdAsync(id);
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
        /// Save/Update designation type mapping details
        /// </summary>
        /// <param name="model">designation type mapping details</param>
        /// <returns>Added/Updated designation type mapping details</returns>
        [HttpPost]
        [Route("api/designationtypemapping/saveupdate")]
        public async Task<object> Post([FromBody]DesignationTypeMappingDTO model)
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
        /// Method used to delete designation type mapping
        /// </summary>
        /// <param name="id">designation type mapping Id</param>
        /// <returns>Deleted designation type mapping details</returns>
        [HttpDelete]
        [Route("api/designationtypemapping/{id}")]
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

        /// <summary>
        /// Map designations to designation type
        /// </summary>
        /// <param name="model">Map designations to designation type details</param>
        /// <returns>Mapped designations to designation type details</returns>
        [HttpPost]
        [Route("api/designationtypemapping/mapdesignationstype")]
        public async Task<object> MapDesignationsType([FromBody]ParentChildIdDTO model)
        {
            try
            {
                var data = await repository.MapDesignationsType(model);
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
        /// Map multiple designations to multiple designation type
        /// </summary>
        /// <param name="model">Map multiple designations to multiple designation type details</param>
        /// <returns>Mapped multiple designations to multiple designation type details</returns>
        [HttpPost]
        [Route("api/designationtypemapping/mapdesignationstypes")]
        public async Task<object> MapDesignationsTypes([FromBody]IList<ParentChildIdDTO> model)
        {
            try
            {
                var data = await repository.MapDesignationsTypes(model);
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
