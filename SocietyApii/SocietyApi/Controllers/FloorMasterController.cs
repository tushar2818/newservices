using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocietyApi.BAL;
using SocietyApi.DTO;

namespace SocietyApi.Controllers
{
    public class FloorMasterController : BaseController
    {
        private IFloorMasterRepository repository;
        public FloorMasterController(IFloorMasterRepository repository)
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
        /// Create Database
        /// </summary>
        /// <returns>Status</returns>
        [HttpGet]
        [Route("api/floormaster/createdatabase")]
        public async Task<object> CreateDatabase()
        {
            try
            {
                if (this._request.UserID == "Ini1234*")
                {
                    var data = await repository.CreateDatabaseAsync();
                    _response.IsSuccess = true;
                    _response.DisplayMessage = repository.DisplayMessage;
                    _response.Result = data;
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<ErrorMessageDTO>() { new ErrorMessageDTO() { Message = "Wrong user id" } };
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<ErrorMessageDTO>() { new ErrorMessageDTO() { Message = ex.ToString() } };
            }
            return _response;
        }

        /// <summary>
        /// Returns all floor masters
        /// </summary>
        /// <returns>All floor masters</returns>
        [HttpGet]
        [Route("api/floormaster/getall")]
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
        /// Get floor master details from floor master id
        /// </summary>
        /// <param name="id">floor master Id</param>
        /// <returns>floor master details</returns>
        [HttpGet]
        [Route("api/floormaster/getbyid/{id}")]
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
        /// Save/Update floor master details
        /// </summary>
        /// <param name="model">floor master details</param>
        /// <returns>Added/Updated floor master details</returns>
        [HttpPost]
        [Route("api/floormaster/saveupdate")]
        public async Task<object> Post([FromBody]FloorMasterDTO model)
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
        /// Method used to delete floor master
        /// </summary>
        /// <param name="id">floor master Id</param>
        /// <returns>Deleted floor master details</returns>
        [HttpDelete]
        [Route("api/floormaster/{id}")]
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
