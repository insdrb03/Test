using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApp_TEST.Models;
using WebApp_TEST.ViewModels;


namespace WebApp_TEST.Security
{
    public class _AuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.Username))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Users", action = "Index" }));
            }
            else
            {
                UserModel um = new UserModel();
                CPrincipal cp = new CPrincipal(um.find_user(SessionPersister.Username));

                if (!cp.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "AccessDenied", action = "Index" }));
                }
            }

        }
    }
}