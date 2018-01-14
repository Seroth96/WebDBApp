using WebDBApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebDBApp.Service_References.Annotation
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

    public class CheckSession : ActionFilterAttribute, IActionFilter
    {
        public string[] Role { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if Session == null => Login page
            if (!Role.Any(role => role.Equals(SessionHelper.GetElement<string>(Enum.SessionElement.Role))))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Index", controller = "Home" }));

            }

            base.OnActionExecuting(filterContext);
        }
    }
}