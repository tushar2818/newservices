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
            string Token = "", ClientID = "", CompanyID = "", UserID = "", PersonID = "", ProjectID = "";

            if (allHeaders.ContainsKey("Token")) Token = allHeaders["Token"];
            if (allHeaders.ContainsKey("ClientID")) ClientID = allHeaders["ClientID"];
            if (allHeaders.ContainsKey("CompanyID")) CompanyID = allHeaders["CompanyID"];
            if (allHeaders.ContainsKey("UserID")) UserID = allHeaders["UserID"];
            if (allHeaders.ContainsKey("PersonID")) PersonID = allHeaders["PersonID"];
            if (allHeaders.ContainsKey("ProjectID")) ProjectID = allHeaders["ProjectID"];

            this._request = new RequestDTO();
            this._response = new ResponseDTO();

            this._request.Token = this._response.Token = Token;
            this._request.ClientID = this._response.ClientID = this.GetIntValue(ClientID);
            this._request.CompanyID = this._response.CompanyID = this.GetIntValue(CompanyID);
            this._request.UserID = this._response.UserID = UserID; 
            this._request.PersonID = this._response.PersonID = this.GetIntValue(PersonID);
            this._request.ProjectID = this._response.ProjectID = this.GetIntValue(ProjectID);

            this.IsTokenVallid();
        }

        public Int64 GetIntValue(string value)
        {
            try
            {
                return Convert.ToInt64(value);
            }
            catch (Exception)
            {
            }
            return 0;
        }

        public void IsTokenVallid()
        {
            //code to validate token
        }
    }
}
