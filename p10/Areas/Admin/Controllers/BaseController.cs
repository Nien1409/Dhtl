using p10.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace p10.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        //Dung session de kiem tra quyen truy cap cua user vao /Admin/Index
        //Null tra ve Controller Login
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Login", Action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}