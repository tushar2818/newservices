using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocietyApi.BAL;
using SocietyApi.DTO;

namespace SocietyApi.Controllers
{
    public class BuildingMasterController : BaseController
    {
        private IBuildingMasterRepository repository;
        public BuildingMasterController(IBuildingMasterRepository repository)
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
        /// Returns all building master
        /// </summary>
        /// <returns>All building masters</returns>
        [HttpGet]
        [Route("api/buildingmaster/getall")]
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
        /// Get building master details from building master id
        /// </summary>
        /// <param name="id">building master Id</param>
        /// <returns>building master Details</returns>
        [HttpGet]
        [Route("api/buildingmaster/getbyid/{id}")]
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
        /// Save/Update building master details
        /// </summary>
        /// <param name="model">building master details</param>
        /// <returns>Added/Updated building master details</returns>
        [HttpPost]
        [Route("api/buildingmaster/saveupdate")]
        public async Task<object> Post([FromBody]BuildingMasterDTO model)
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
        /// Method used to delete building master
        /// </summary>
        /// <param name="id">building master Id</param>
        /// <returns>Deleted building master details</returns>
        [HttpDelete]
        [Route("api/buildingmaster/{id}")]
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
