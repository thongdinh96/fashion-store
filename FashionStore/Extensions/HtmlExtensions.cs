using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace FashionStore.Extensions
{
    public static class HtmlExtensions
    {
        public static string BuildBreadcrumbNavigation(this HtmlHelper helper)
        {
            string controllerName = helper.ViewContext.RouteData.Values["controller"].ToString();
            string actionName = helper.ViewContext.RouteData.Values["action"].ToString();
            string id = helper.ViewContext.RouteData.Values["id"]?.ToString();
            StringBuilder breadcrumb = new StringBuilder("<ol class='breadcrumb float-sm-right'><li class='breadcrumb-item'>").Append(helper.ActionLink("Dashboard", "Index", "Admin").ToHtmlString()).Append("</li>");
            if (controllerName.ToLower() == "admin")
            {
                return breadcrumb.Append("</ol>").ToString();
            }

            breadcrumb.Append("<li class='breadcrumb-item'>");
            breadcrumb.Append(helper.ActionLink(controllerName, "Index", controllerName).ToHtmlString());
            breadcrumb.Append("</li>");

            if (actionName != "Index")
            {
                breadcrumb.Append("<li class='breadcrumb-item'>");
                if (actionName.ToLower() != "details" && actionName.ToLower() != "edit" && actionName.ToLower() != "delete")
                {
                    breadcrumb.Append(helper.ActionLink(actionName, actionName, controllerName).ToHtmlString());
                }
                else
                {
                    breadcrumb.Append(actionName);
                }
                breadcrumb.Append("</li>");
                if (id != null)
                {
                    breadcrumb.Append("<li class='breadcrumb-item'>");
                    breadcrumb.Append(helper.ActionLink(id, "details", controllerName, id, null).ToHtmlString());
                    breadcrumb.Append("</li>");
                }
            }

            return breadcrumb.Append("</ol>").ToString();
        }
    }

    public static class StringExtensions
    {
        public static string Titleize(this string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text).ToSentenceCase();
        }

        public static string ToSentenceCase(this string str)
        {
            return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
        }
    }
}
