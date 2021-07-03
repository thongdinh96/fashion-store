using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using FashionStore.Filters;
using System.Web.Mvc;
using FashionStore.Models;
using System.Web;
using System.IO;
using System.Data.Entity.Migrations;

namespace FashionStore.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        [AdminFilter]
        [Route("admin/products")]
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Collection).Include(p => p.Supplier);
            ViewBag.ActiveItem = "productLst";
            return View(products.ToList());
        }

        // GET: Products/Details/5
        [Route("admin/products/{id}")]
        [AdminFilter]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Include(p => p.Sizes).FirstOrDefault(p => p.ProductId == id);            
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        [AdminFilter]
        [Route("admin/products/create")]
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
            List<Collection> collLst = db.Collections.ToList();
            collLst.Insert(0, no);
            ViewBag.CollectionId = new SelectList(collLst, "CollectionId", "CollectionName", no);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName");
            ViewBag.ActiveItem = "productCreate";

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Route("admin/products/create")]

        public ActionResult Create([Bind(Include = "ProductId,ProductName,CategoryId,SupplierId,UnitPrice,Color,Discount,UnitsInStock,UnitsOnOrder,ProductAvailable,Picture,Note,CollectionId")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.Picture = string.Empty;
                if (Request.Files[0].FileName.Length != 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFileBase file = Request.Files[i];
                        file.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Products", file.FileName));
                        product.Picture += file.FileName + ";";

                    } 
                }
                product.Picture = product.Picture.TrimEnd(';');
                product.Created = DateTime.Now;
                if (product.CollectionId == 0)
                {
                    product.CollectionId = null;
                }
                db.Products.Add(product);
                db.SaveChanges();
                AddOrUpdateProductSizes(product.ProductId);
                
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.CollectionId = new SelectList(db.Collections, "CollectionId", "CollectionName", product.CollectionId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        private void AddOrUpdateProductSizes(int productId)
        {
            List<Size> updateSizeLst = new List<Size>();
            List<Size> removeSizeLst = new List<Size>();
            Size temp;
            if (Request.Form["ckS"] == "true,false")
            {
                Size sSize = new Size()
                {
                    ProductId = productId,
                    SizeName = SizeEnum.S,
                    Amount = Convert.ToInt32(Request.Form["SAmount"])
                };
                updateSizeLst.Add(sSize);
            }
            else
            {
                temp = db.Sizes.SingleOrDefault(s => s.ProductId == productId && s.SizeName == SizeEnum.S);
                if (temp!=null)
                {
                    removeSizeLst.Add(temp);
                }
            }
            if (Request.Form["ckXS"] == "true,false")
            {
                Size xSSize = new Size()
                {
                    ProductId = productId,
                    SizeName = SizeEnum.XS,
                    Amount = Convert.ToInt32(Request.Form["XSAmount"])
                };
                updateSizeLst.Add(xSSize);

            }
            else
            {
                temp = db.Sizes.SingleOrDefault(s => s.ProductId == productId && s.SizeName == SizeEnum.XS);
                if (temp != null)
                {
                    removeSizeLst.Add(temp);
                }
            }
            if (Request.Form["ckM"] == "true,false")
            {
                Size MSize = new Size()
                {
                    ProductId = productId,
                    SizeName = SizeEnum.M,
                    Amount = Convert.ToInt32(Request.Form["MAmount"])
                };
                updateSizeLst.Add(MSize);

            }
            else
            {
                temp = db.Sizes.SingleOrDefault(s => s.ProductId == productId && s.SizeName == SizeEnum.M);
                if (temp != null)
                {
                    removeSizeLst.Add(temp);
                }
            }
            if (Request.Form["ckL"] == "true,false")
            {
                Size LSize = new Size()
                {
                    ProductId = productId,
                    SizeName = SizeEnum.L,
                    Amount = Convert.ToInt32(Request.Form["LAmount"])
                };
                updateSizeLst.Add(LSize);

            }
            else
            {
                temp = db.Sizes.SingleOrDefault(s => s.ProductId == productId && s.SizeName == SizeEnum.L);
                if (temp != null)
                {
                    removeSizeLst.Add(temp);
                }
            }
            if (Request.Form["ckXL"] == "true,false")
            {
                Size XLSize = new Size()
                {
                    ProductId = productId,
                    SizeName = SizeEnum.XL,
                    Amount = Convert.ToInt32(Request.Form["XLAmount"])
                };
                updateSizeLst.Add(XLSize);

            }
            else
            {
                temp = db.Sizes.SingleOrDefault(s => s.ProductId == productId && s.SizeName == SizeEnum.XL);
                if (temp != null)
                {
                    removeSizeLst.Add(temp);
                }
            }
            if (Request.Form["ckXXL"] == "true,false")
            {
                Size XXLSize = new Size()
                {
                    ProductId = productId,
                    SizeName = SizeEnum.XXL,
                    Amount = Convert.ToInt32(Request.Form["XXLAmount"])
                };
                updateSizeLst.Add(XXLSize);
            }
            else
            {
                temp = db.Sizes.SingleOrDefault(s => s.ProductId == productId && s.SizeName == SizeEnum.XXL);
                if (temp != null)
                {
                    removeSizeLst.Add(temp);
                }
            }
            updateSizeLst.ForEach(size => db.Sizes.AddOrUpdate(s => new { s.SizeName, s.ProductId }, size));
            removeSizeLst.ForEach(size => db.Sizes.Remove(size));
            db.SaveChanges();
        }

        // GET: Products/Edit/5
        [AdminFilter]
        [Route("admin/products/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            Dictionary<SizeEnum, Size> sizeDic = db.Sizes.Select(size => size).Where(s => s.ProductId == id).ToDictionary(s => s.SizeName);
            if (sizeDic.ContainsKey(SizeEnum.XS))
            {
                ViewBag.XS = true;
                ViewBag.XSAmount = sizeDic[SizeEnum.XS].Amount;
            }
            else
            {
                ViewBag.XS = false;
                ViewBag.XSAmount = 1;
            }
            if (sizeDic.ContainsKey(SizeEnum.S))
            {
                ViewBag.S = true;
                ViewBag.SAmount = sizeDic[SizeEnum.S].Amount;
            }
            else
            {
                ViewBag.S = false;
                ViewBag.SAmount = 1;
            }
            if (sizeDic.ContainsKey(SizeEnum.M))
            {
                ViewBag.M = true;
                ViewBag.MAmount = sizeDic[SizeEnum.M].Amount;
            }
            else
            {
                ViewBag.M = false;
                ViewBag.MAmount = 1;
            }
            if (sizeDic.ContainsKey(SizeEnum.L))
            {
                ViewBag.L = true;
                ViewBag.LAmount = sizeDic[SizeEnum.L].Amount;
            }
            else
            {
                ViewBag.L = false;
                ViewBag.LAmount = 1;
            }
            if (sizeDic.ContainsKey(SizeEnum.XL))
            {
                ViewBag.XL = true;
                ViewBag.XLAmount = sizeDic[SizeEnum.XL].Amount;
            }
            else
            {
                ViewBag.XL = false;
                ViewBag.XLAmount = 1;
            }
            if (sizeDic.ContainsKey(SizeEnum.XXL))
            {
                ViewBag.XXL = true;
                ViewBag.XXLAmount = sizeDic[SizeEnum.XXL].Amount;
            }
            else
            {
                ViewBag.XXL = false;
                ViewBag.XXLAmount = 1;
            }
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            Collection no = new Collection { CollectionId = 0, CollectionName = "No collection" };
            List<Collection> collLst = db.Collections.ToList();
            collLst.Insert(0, no);
            ViewBag.CollectionId = new SelectList(collLst, "CollectionId", "CollectionName", product.CollectionId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("admin/products/edit/{id}")]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,CategoryId,SupplierId,UnitPrice,Color,Discount,UnitsInStock,UnitsOnOrder,ProductAvailable,DiscountAvailable,Picture,Note,CollectionId,Created")] Product product)
        {
            if (ModelState.IsValid)
            {

                product.Picture = string.Empty;
                if (Request.Files[0].FileName.Length != 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFileBase file = Request.Files[i];
                        file.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Products", file.FileName));
                        product.Picture += file.FileName + ";";

                    }
                }
                product.Picture = product.Picture.TrimEnd(';');
                product.Modified = DateTime.Now;
                if (product.CollectionId == 0)
                {
                    product.CollectionId = null;
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                AddOrUpdateProductSizes(product.ProductId);
                return RedirectToAction("Index");
            }
            List<Collection> collLst = db.Collections.ToList();
            Collection no = new Collection { CollectionId = 0, CollectionName = "No collection" };
            collLst.Insert(0, no);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.CollectionId = new SelectList(collLst, "CollectionId", "CollectionName", product.CollectionId);
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
