using IdentityService.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace IdentityService
{
    public class BaseController : Controller
    {
        protected IRequestDTO _request { get; set; }
        protected ResponseDTO _response;

        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            base.OnActionExecuting(ctx);
            var allHeaders = this.ControllerContext.HttpContext.Request.Headers;
            string applicationId = "", applicationToken = "";

            if (allHeaders.ContainsKey("ApplicationId")) applicationId = allHeaders["ApplicationId"];
            if (allHeaders.ContainsKey("ApplicationToken")) applicationToken = allHeaders["ApplicationToken"];

            this._request = new RequestDTO();
            this._response = new ResponseDTO();

            this._request.applicationId = this._response.applicationId = applicationId;
            this._request.applicationToken = this._response.applicationToken = applicationToken;
            this.IsTokenVallid();
        }

        public void IsTokenVallid()
        {
            //code to validate token
        }
    }
}
