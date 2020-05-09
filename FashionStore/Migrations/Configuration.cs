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
        }
    }
}
