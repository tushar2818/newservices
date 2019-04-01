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
    public class IdentityController : BaseController
    {
        private IIdentityRepository _repository;

        public IdentityController(IIdentityRepository repository)
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
            _repository.roleManager.Dispose();
            _repository.userRepository.Dispose();
            _repository.roleRepository.Dispose();
            _repository.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Validate user credentials
        /// </summary>
        /// <param name="model">user credentials</param>
        /// <returns>user status</returns>
        [HttpPost]
        [Route("api/identity/validateuser")]
        public async Task<object> ValidateUser([FromBody]UserCredentialDTO model)
        {
            try
            {
                var data = await _repository.ValidateUser(model);
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
        ///  Add/Update users in role
        /// </summary>
        /// <param name="model">Users in role</param>
        /// <returns>status</returns>
        [HttpPost]
        [Route("api/identity/addusersinrole")]
        public async Task<object> AddUsersInRole([FromBody]UsersInRoleDTO model)
        {
            try
            {
                var data = await _repository.AddUsersInRole(model);
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
        /// returns users is role
        /// </summary>
        /// <param name="roleid">role id</param>
        /// <returns>users is role</returns>
        [HttpGet]
        [Route("api/identity/getusersinrole/{roleid}")]
        public async Task<object> GetUsersInRole(string roleid)
        {
            try
            {
                var data = await _repository.GetUsersInRole(roleid);
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
