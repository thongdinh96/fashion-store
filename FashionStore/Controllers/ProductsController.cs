using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using FashionStore.Filters;
using System.Web.Mvc;
using FashionStore.Models;

namespace FashionStore.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        [AdminFilter]
        [Route("admin/product")]
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Collection).Include(p => p.Supplier);
            ViewBag.ActiveItem = "productLst";
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        [AdminFilter]
        [Route("admin/product/create")]
        public ActionResult Create()
        {
            Collection no = new Collection { CollectionId = 0, CollectionName = "No collection" };

            List<Category> catesQuery =
                        (from c in db.Categories
                         where !(from ca in db.Categories
                                 select ca.CategoryParentId)
                                .Contains(c.CategoryId)
                         select c).ToList();
            ViewBag.CategoryId = new SelectList(catesQuery, "CategoryId", "CategoryName");
            ViewBag.CollectionId = new SelectList(db.Collections, "CollectionId", "CollectionName", no);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName");
            ViewBag.ActiveItem = "productCreate";

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,CategoryId,SupplierId,UnitPrice,Size,Color,Discount,UnitsInStock,UnitsOnOrder,ProductAvailable,DiscountAvailable,Picture,Ranking,Note,CollectionId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.CollectionId = new SelectList(db.Collections, "CollectionId", "CollectionName", product.CollectionId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // GET: Products/Edit/5
        [AdminFilter]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.CollectionId = new SelectList(db.Collections, "CollectionId", "CollectionName", product.CollectionId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,CategoryId,SupplierId,UnitPrice,Size,Color,Discount,UnitsInStock,UnitsOnOrder,ProductAvailable,DiscountAvailable,Picture,Ranking,Note,CollectionId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.CollectionId = new SelectList(db.Collections, "CollectionId", "CollectionName", product.CollectionId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // GET: Products/Delete/5
        [AdminFilter]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
