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
    public class RoleController : BaseController
    {
        private IRoleRepository _repository;
        public RoleController(IRoleRepository repository)
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
            _repository.roleManager.Dispose();
            _repository.Dispose();
            base.Dispose(disposing);
        } 

        /// <summary>
        /// Returns all roles
        /// </summary>
        /// <returns>List of roles</returns>
        [HttpGet]
        [Route("api/roles/getall")]
        public async Task<object> GetAll()
        {
            try
            {
                var data = await _repository.GetAllAsync();
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
        /// Returns roles details from role id
        /// </summary>
        /// <param name="id">role id</param>
        /// <returns>Role Details</returns>
        [HttpGet]
        [Route("api/roles/getbyid/{id}")]
        public async Task<object> GetById(string id)
        {
            try
            {
                var data = await _repository.GetByIdAsync(id);
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
        /// Add/Update role
        /// </summary>
        /// <param name="model">role details</param>
        /// <returns>Added/Updated role details</returns>
        [HttpPost]
        [Route("api/roles/saveupdate")]
        public async Task<object> Post([FromBody]ApplicationRoleDTO model)
        {
            try
            {
                var data = await _repository.SaveUpdateAsync(model);
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
        /// Delete role details
        /// </summary>
        /// <param name="id">role id</param>
        /// <returns>Deleted roles details</returns>
        [HttpDelete]
        [Route("api/roles/{id}")]
        public async Task<object> Delete(string id)
        {
            try
            {
                var data = await _repository.DeleteAsync(id);
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
