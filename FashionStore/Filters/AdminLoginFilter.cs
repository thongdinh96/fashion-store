using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using FashionStore.Models;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace FashionStore.Filters
{
    public class AdminLoginFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.Principal.Identity.IsAuthenticated == true)
            {
                if (filterContext.Principal.IsInRole("admin"))
                {
                    filterContext.Result = new RedirectToRouteResult(
                                    new RouteValueDictionary
                                    {
                    { "controller", "admin" },
                    { "action", "index" }
                                    });
                }
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
}
