using SocietyApi.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace SocietyApi
{
    public class BaseController : Controller
    {
        protected IRequestDTO _request { get; set; }
        protected ResponseDTO _response;

        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            base.OnActionExecuting(ctx);
            var allHeaders = this.ControllerContext.HttpContext.Request.Headers;
            string Token = "", ClientID = "", CompanyID = "", UserID = "";

            if (allHeaders.ContainsKey("Token")) Token = allHeaders["Token"];
            if (allHeaders.ContainsKey("ClientID")) ClientID = allHeaders["ClientID"];
            if (allHeaders.ContainsKey("CompanyID")) CompanyID = allHeaders["CompanyID"];
            if (allHeaders.ContainsKey("UserID")) UserID = allHeaders["UserID"];

            this._request = new RequestDTO();
            this._response = new ResponseDTO();

            this._request.Token = this._response.Token = Token;
            this._request.ClientID = this._response.ClientID = ClientID;
            this._request.CompanyID = this._response.CompanyID = CompanyID;
            this._request.UserID = this._response.UserID = UserID; 

            this.IsTokenVallid();
        }

        public void IsTokenVallid()
        {
            //code to validate token
        }
    }
}
