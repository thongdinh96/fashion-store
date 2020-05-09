using HtmlAgilityPack;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FashionStore.Models;
using FashionStore.Filters;
using System.Collections.Generic;

namespace FashionStore.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Category
        [Route("admin/category")]
        [AdminFilter]
        public ActionResult Index()
        {
            //List<Category> lstCates = new List<Category>();
            //int i = 0;
            //while (lstCates[i].CategoryParentId != 0 && i < lstCates.Count)
            //{
            //    i++;
            //}
            //HtmlNode rootTblCate = HtmlNode.CreateNode("<table><thead><tr><th></th><th>Category name</th><th>Category description</th><th>Active</th></tr></thead><tbody></tbody></table>");
            //HtmlNode row = HtmlNode.CreateNode($"<tr id=\"ca_{lstCates[i].CategoryId}\"></tr>");
            //BuildCategoryTable(rootTblCate, row, lstCates);
            ViewBag.ActiveItem = "cateLstLink";
            return View(db.Categories.ToList());
        }

        private void BuildCategoryTable(HtmlNode node, HtmlNode row, List<Category> lstCates)
        {
            if (lstCates.Count == 0)
            {
                return;
            }
            // append row to node
            if (row.Attributes["id"].Value == "0")
            {
                //node.SelectSingleNode
            }
            // find node in list if it have parent id in rootTbl
            // or its parentid is 0
            // remove that node in lst
            // recursive with append node and row created
        }

        // GET: Category/Details/5
        [Route("admin/category/details/{id}")]
        [AdminFilter]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            List<Category> childrenCates = (from Category in db.Categories
                                            where Category.CategoryParentId == id
                                            select Category).ToList();
            ViewBag.ChildrenCates = childrenCates;
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Category/Create
        [Route("admin/category/create")]
        [AdminFilter]
        public ActionResult Create()
        {
            var catesLst = db.Categories.ToList();
            Category no = new Category { CategoryId = 0, CategoryName = "No parent" };
            catesLst.Insert(0, no);
            SelectList parentCateSl = new SelectList(catesLst, "CategoryId", "CategoryName", no);
            ViewBag.CategoryParentId = parentCateSl;
            ViewBag.ActiveItem = "cateAddLink";

            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,Description,CategoryParentId,Active")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Category/Edit/5
        [Route("admin/category/edit/{id}")]
        [AdminFilter]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            ViewBag.CategoryParentId = new SelectList(db.Categories, "CategoryId", "CategoryName", category.CategoryParentId);

            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,Description,CategoryParentId,Active")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Category/Delete/5
        [Route("admin/category/delete/{id}")]
        [AdminFilter]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Include("CategoryParent").SingleOrDefault(ca => ca.CategoryId == id);
            
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
