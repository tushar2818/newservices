﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocietyApi.BAL;
using SocietyApi.DTO;

namespace SocietyApi.Controllers
{
    public class WingMasterController : BaseController
    {
        private IWingMasterRepository repository;
        public WingMasterController(IWingMasterRepository repository)
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
        /// Returns all wing masters
        /// </summary>
        /// <returns>All wing masters</returns>
        [HttpGet]
        [Route("api/wingmaster/getall/{buildingmasteriD}")]
        public async Task<object> GetAll(Int64 buildingmasteriD)
        {
            try
            {
                var data = await repository.GetAllAsync(buildingmasteriD);
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
        /// Get wing master details from wing master id
        /// </summary>
        /// <param name="id">wing master Id</param>
        /// <returns>wing master details</returns>
        [HttpGet]
        [Route("api/wingmaster/getbyid/{id}")]
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
        /// Save/Update wing master details
        /// </summary>
        /// <param name="model">wing master details</param>
        /// <returns>Added/Updated wing master details</returns>
        [HttpPost]
        [Route("api/wingmaster/saveupdate")]
        public async Task<object> Post([FromBody]WingMasterDTO model)
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
        /// Method used to delete wing master
        /// </summary>
        /// <param name="id">wing master Id</param>
        /// <returns>Deleted wing master details</returns>
        [HttpDelete]
        [Route("api/wingmaster/{id}")]
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
