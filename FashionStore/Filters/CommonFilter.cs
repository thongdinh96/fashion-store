using FashionStore.Models;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System;
using HtmlAgilityPack;

namespace FashionStore.Filters
{
    public class CommonFilter : ActionFilterAttribute
    {
        #region Public methods
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

            // Lấy list categories đẩy vào ViewBag
            List<Category> categoriesMenu = GetCategoriesMenu();

            // Tạo chuỗi ul li dạng cha con
            //string categoriesTree = BuildCategoriesTree(categoriesMenu);
        }

        //private string BuildCategoriesTree(List<Category> categoriesMenu)
        //{
        //    var doc = new HtmlDocument();
        //    var rootNode = HtmlNode.CreateNode("<ul></ul>");
        //    doc.DocumentNode.AppendChild(rootNode);
        //}
        #endregion

        #region Private methods
        private List<Category> GetCategoriesMenu()
        {
            List<Category> categoriesList = new List<Category>();
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                categoriesList = (from category in ctx.Categories
                                  select category).ToList();
            }

            return categoriesList;
        }
        #endregion



    }
}
