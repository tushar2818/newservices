using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityService.BAL;
using IdentityService.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
//https://github.com/aspnet/Identity/issues/351
namespace IdentityService.Controllers
{
    public class UserController : BaseController
    {
        private IUserRepository _repository;
        public UserController(IUserRepository repository)
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
            _repository.userManager.Dispose();
            _repository.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        [Route("api/user/getall")]
        public async Task<object> GetAll()
        {
            try
            {
                var data = await _repository.GetAll();
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
        /// Returns user details from user id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>user Details</returns>
        [HttpGet]
        [Route("api/user/getbyid/{id}")]
        public async Task<object> GetById(string id)
        {
            try
            {
                var data = await _repository.GetById(id);
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
        /// Add/Update user
        /// </summary>
        /// <param name="model">user details</param>
        /// <returns>Added/Updated user details</returns>
        [HttpPost]
        [Route("api/user/saveupdate")]
        public async Task<object> Post([FromBody]ApplicationUserDTO model)
        {
            try
            {
                var data = await _repository.SaveUpdate(model);
                _response.Result = data;
                _response.IsSuccess = _repository.IsSuccess;
                _response.ErrorMessages = _repository.ErrorMessages;
                _response.DisplayMessage = _repository.DisplayMessage;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<ErrorMessageDTO>() { new ErrorMessageDTO() { Message = ex.ToString() } };
            }
            return _response;
        }

        /// <summary>
        /// Delete user details
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>Deleted user details</returns>
        [HttpDelete]
        [Route("api/user/{id}")]
        public async Task<object> Delete(string id)
        {
            try
            {
                var data = await _repository.Delete(id);
                _response.Result = data;
                _response.IsSuccess = _repository.IsSuccess;
                _response.ErrorMessages = _repository.ErrorMessages;
                _response.DisplayMessage = _repository.DisplayMessage;
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
