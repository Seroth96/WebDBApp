using Login.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Service_References.Annotation
{
    public sealed class SessionExpireFilter : ActionFilterAttribute, IActionFilter
    {
        private readonly List<string> NonSessionValidatedUrls = new List<string>()
        {
            //"/",
            "/Login/Login",
            "/Login/Index",
            "/Login/Register",
            "/Login/Reset"
        };

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (NonSessionValidatedUrls.All(x => x != filterContext.HttpContext.Request.CurrentExecutionFilePath)
                 && SessionHelper.GetElement<string>(Enum.SessionElement.Login) == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = 401;
                    filterContext.HttpContext.Response.End();
                }
                else
                    filterContext.Result = new RedirectResult("~/Login/Index");
            }
        }
    }
}