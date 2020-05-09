using FashionStore.Models;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace FashionStore.Filters
{
    public class AdminFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.Principal.Identity.IsAuthenticated == false)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                        {
                    { "controller", "admin" },
                    { "action", "login" }
                        });
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            ApplicationUser user = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                string usrId = filterContext.HttpContext.User.Identity.GetUserId();

                user = (from usr in ctx.Users
                        where usr.Id == usrId
                        select usr).SingleOrDefault();

            }
            filterContext.Controller.ViewBag.AU = user;
        }
    }
}
