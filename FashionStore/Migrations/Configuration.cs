namespace FashionStore.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FashionStore.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FashionStore.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FashionStore.Models.ApplicationDbContext";
        }

        protected override void Seed(FashionStore.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            List<Category> categories = new List<Category>() {
                new Category()
                {
                    Active = true,
                    CategoryName = "Woman",
                    Description = "Fashion for woman"
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Man",
                    Description = "Fashion for man"
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Kid",
                    Description = "Fashion for kid"
                }
            };

            categories.ForEach(c => context.Categories.AddOrUpdate(ca => ca.CategoryName, c));
            context.SaveChanges();
            int womanId = context.Categories.SingleOrDefault(c => c.CategoryName == "Woman").CategoryId;
            int manId = context.Categories.SingleOrDefault(c => c.CategoryName == "Man").CategoryId;
            int kidId = context.Categories.SingleOrDefault(c => c.CategoryName == "Kid").CategoryId;


            categories = new List<Category>() {
                new Category()
                {
                    Active = true,
                    CategoryName = "Clothes",
                    CategoryParentId = womanId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Shoes",
                    CategoryParentId = womanId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Clothes",
                    CategoryParentId = manId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Shoes",
                    CategoryParentId = manId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Girl",
                    CategoryParentId = kidId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Boy",
                    CategoryParentId = kidId
                }
            };
            categories.ForEach(c => context.Categories.AddOrUpdate(ca => new { ca.CategoryName, ca.CategoryParentId }, c));
            context.SaveChanges();
            int clothesWomanId = context.Categories.SingleOrDefault(c => c.CategoryName == "Clothes" && c.CategoryParentId == womanId).CategoryId;
            int shoesWomanId = context.Categories.SingleOrDefault(c => c.CategoryName == "Shoes" && c.CategoryParentId == womanId).CategoryId;
            int clothesManId = context.Categories.SingleOrDefault(c => c.CategoryName == "Clothes" && c.CategoryParentId == manId).CategoryId;
            int shoesManId = context.Categories.SingleOrDefault(c => c.CategoryName == "Shoes" && c.CategoryParentId == manId).CategoryId;
            int girlKidId = context.Categories.SingleOrDefault(c => c.CategoryName == "Girl" && c.CategoryParentId == kidId).CategoryId;
            int boyKidId = context.Categories.SingleOrDefault(c => c.CategoryName == "Boy" && c.CategoryParentId == kidId).CategoryId;
            categories = new List<Category>() {
                new Category()
                {
                    Active = true,
                    CategoryName = "Dresses",
                    CategoryParentId = clothesWomanId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Jeans",
                    CategoryParentId = clothesWomanId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Tunics",
                    CategoryParentId = clothesWomanId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Pumps",
                    CategoryParentId = shoesWomanId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Sandals",
                    CategoryParentId = shoesWomanId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Sneakers",
                    CategoryParentId = shoesWomanId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Shirts",
                    CategoryParentId = clothesManId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Jeans",
                    CategoryParentId = clothesManId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "T-shirts",
                    CategoryParentId = clothesManId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Flip-flops",
                    CategoryParentId = shoesManId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Sandals",
                    CategoryParentId = shoesManId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Sneakers",
                    CategoryParentId = shoesManId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Dresses",
                    CategoryParentId = girlKidId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Shoes",
                    CategoryParentId = girlKidId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Skirts",
                    CategoryParentId = girlKidId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Jeans",
                    CategoryParentId = boyKidId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Shorts",
                    CategoryParentId = boyKidId
                },
                new Category()
                {
                    Active = true,
                    CategoryName = "Vests",
                    CategoryParentId = boyKidId
                }
            };
            categories.ForEach(c => context.Categories.AddOrUpdate(ca => new { ca.CategoryName, ca.CategoryParentId }, c));
            context.SaveChanges();

            List<Collection> colls = new List<Collection>() {
                new Collection
                {
                    CollectionName = "LAST QUEEN",
                    Created = DateTime.Now
                },
                new Collection
                {
                    CollectionName = "ZOE MODE",
                    Created = DateTime.Now
                },
                new Collection
                {
                    CollectionName = "D.CHERRI",
                    Created = DateTime.Now
                },
                new Collection
                {
                    CollectionName = "MARIVY",
                    Created = DateTime.Now
                },
                new Collection
                {
                    CollectionName = "R AND BE",
                    Created = DateTime.Now
                },
                new Collection
                {
                    CollectionName = "POTI PATI",
                    Created = DateTime.Now
                },
                new Collection
                {
                    CollectionName = "WS SHOES",
                    Created = DateTime.Now
                },
                new Collection
                {
                    CollectionName = "JM. DIAMANT",
                    Created = DateTime.Now
                },
                new Collection
                {
                    CollectionName = "DIELE & CO",
                    Created = DateTime.Now
                },
                new Collection
                {
                    CollectionName = "RG512",
                    Created = DateTime.Now
                },
                new Collection
                {
                    CollectionName = "BLACK INDUSTRY",
                    Created = DateTime.Now
                },
                new Collection
                {
                    CollectionName = "ZAYNE PARIS",
                    Created = DateTime.Now
                },
                new Collection
                {
                    CollectionName = "KOLORIS",
                    Created = DateTime.Now
                },
                new Collection
                {
                    CollectionName = "SQUARED & CUBED",
                    Created = DateTime.Now
                },
                new Collection
                {
                    CollectionName = "STAR PARIS",
                    Created = DateTime.Now
                },
                new Collection
                {
                    CollectionName = "CORALINE KIDS",
                    Created = DateTime.Now
                },
                new Collection
                {
                    CollectionName = "ELONG",
                    Created = DateTime.Now
                }

            };
            colls.ForEach(coll => context.Collections.AddOrUpdate(co => co.CollectionName, coll));
            context.SaveChanges();
            int lastQueenId = context.Collections.SingleOrDefault(col => col.CollectionName == "LAST QUEEN").CollectionId;
            
            int zoeModeId = context.Collections.SingleOrDefault(col => col.CollectionName == "ZOE MODE").CollectionId;
            int dCherriId = context.Collections.SingleOrDefault(col => col.CollectionName == "D.CHERRI").CollectionId;
            int marivyId = context.Collections.SingleOrDefault(col => col.CollectionName == "MARIVY").CollectionId;
            int rAndBeId = context.Collections.SingleOrDefault(col => col.CollectionName == "R AND BE").CollectionId;
            int potiPatiId = context.Collections.SingleOrDefault(col => col.CollectionName == "POTI PATI").CollectionId;
            int wsShoesId = context.Collections.SingleOrDefault(col => col.CollectionName == "WS SHOES").CollectionId;
            int jmDiamantId = context.Collections.SingleOrDefault(col => col.CollectionName == "JM. DIAMANT").CollectionId;
            int dieleAndCoId = context.Collections.SingleOrDefault(col => col.CollectionName == "DIELE & CO").CollectionId;
            int rg512Id = context.Collections.SingleOrDefault(col => col.CollectionName == "RG512").CollectionId;
            int blackIndustryId = context.Collections.SingleOrDefault(col => col.CollectionName == "BLACK INDUSTRY").CollectionId;
            int zayneParisId = context.Collections.SingleOrDefault(col => col.CollectionName == "ZAYNE PARIS").CollectionId;
            int kolorisId = context.Collections.SingleOrDefault(col => col.CollectionName == "KOLORIS").CollectionId;
            int squaredAndCubeId = context.Collections.SingleOrDefault(col => col.CollectionName == "SQUARED & CUBED").CollectionId;
            int starParisId = context.Collections.SingleOrDefault(col => col.CollectionName == "STAR PARIS").CollectionId;
            int coralineKidsId = context.Collections.SingleOrDefault(col => col.CollectionName == "CORALINE KIDS").CollectionId;
            int elongId = context.Collections.SingleOrDefault(col => col.CollectionName == "ELONG").CollectionId;
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    CategoryId = 10,
                    CollectionId = lastQueenId,
                    ProductName = "Long dress with bohemian print embroidered with shells",
                    ProductAvailable = true,
                    UnitPrice = 100,
                    Created = DateTime.Now
                },
                new Product()
                {
                    CategoryId = 10,
                    CollectionId = zoeModeId,
                    ProductName = "Maxi printed dress",
                    ProductAvailable = true,

                    UnitPrice = 200,
                    Created = DateTime.Now
                },
                new Product()
                {
                    CategoryId = 11,
                    CollectionId = marivyId,
                    ProductName = "Ripped jeans",
                    ProductAvailable = true,
                    Created=DateTime.Now,
                    UnitPrice = 500
                },
                new Product()
                {
                    CategoryId = 11,
                    CollectionId = dCherriId,
                    ProductName = "Ripped skinny jeans",
                    ProductAvailable = true,
                    Created=DateTime.Now,

                    UnitPrice = 300
                },
                new Product()
                {
                    CategoryId = 12,
                    CollectionId = lastQueenId,
                    ProductName = "Loose tunic dress with floral print, satin fabric",
                    ProductAvailable = true,
                    Created=DateTime.Now,

                    UnitPrice = 540
                },
                new Product()
                {
                    CategoryId = 13,
                    CollectionId = wsShoesId,
                    ProductName = "PUMPS",
                    ProductAvailable = true,
                    Created=DateTime.Now,

                    UnitPrice = 350
                },
                new Product()
                {
                    CategoryId = 13,
                    CollectionId = jmDiamantId,
                    ProductName = "Escarpins",
                    ProductAvailable = true,
                    Created=DateTime.Now,

                    UnitPrice = 550
                },
                new Product()
                {
                    CategoryId = 14,
                    CollectionId = rAndBeId,
                    ProductName = "Sandals flat",
                    ProductAvailable = true,
                    Created=DateTime.Now,

                    UnitPrice = 350
                },
                new Product()
                {
                    CategoryId = 14,
                    CollectionId = potiPatiId,
                    ProductName = "SANDALS HEELS",
                    ProductAvailable = true,
                    Created=DateTime.Now,

                    UnitPrice = 390
                },
                new Product()
                {
                    CategoryId = 15,
                    CollectionId = jmDiamantId,
                    ProductName = "Wedges sneakers",
                    ProductAvailable = true,
                    Created=DateTime.Now,

                    UnitPrice = 450
                },
                new Product()
                {
                    CategoryId = 15,
                    CollectionId = wsShoesId,
                    ProductName = "SNEAKERS",
                    ProductAvailable = true,
                    Created=DateTime.Now,

                    UnitPrice = 400
                },
                new Product()
                {
                    CategoryId = 16,
                    CollectionId = dieleAndCoId,
                    ProductName = "Black denim shirt",
                    ProductAvailable = true,
                    Created=DateTime.Now,

                    UnitPrice = 470
                },
                new Product()
                {
                    CategoryId = 16,
                    CollectionId = rg512Id,
                    ProductName = "Shirt with short sleeves RG512 from S to XL",
                    ProductAvailable = true,
                    Created=DateTime.Now,

                    UnitPrice = 500
                },
                new Product()
                {
                    CategoryId = 17,
                    CollectionId = blackIndustryId,
                    ProductName = "4585",
                    ProductAvailable = true,
                    Created=DateTime.Now,

                    UnitPrice = 480
                },
                new Product()
                {
                    CategoryId = 17,
                    CollectionId = blackIndustryId,
                    ProductName = "4590-0",
                    ProductAvailable = true,
                    Created=DateTime.Now,

                    UnitPrice = 590
                },
                new Product()
                {
                    CategoryId = 18,
                    CollectionId = zayneParisId,
                    ProductName = "Tshirt with strass",
                    ProductAvailable = true,
                    Created=DateTime.Now,

                    UnitPrice = 380
                },
                //new Product()
                //{
                //    CategoryId = 18,
                //    CollectionId = kolorisId,
                //    ProductName = "Tee-shirt Marine Homme - Profil",
                //    ProductAvailable = true,

                //    UnitPrice = 600
                //},
                //new Product()
                //{
                //    CategoryId = 20,
                //    CollectionId = elongId,
                //    ProductAvailable = true,

                //    UnitPrice = 50
                //},
                //new Product()
                //{
                //    CategoryId = 21,
                //    CollectionId = jmDiamantId,
                //    ProductAvailable = true,

                //    UnitPrice = 120
                //},
                //new Product()
                //{
                //    CategoryId = 21,
                //    CollectionId = elongId,
                //    ProductAvailable = true,

                //    UnitPrice = 90
                //}
            };
            products.ForEach(pro => context.Products.AddOrUpdate(p => new { p.ProductName, p.CategoryId, p.CollectionId }, pro));
            context.SaveChanges();

        }
    }
}
