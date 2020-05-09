namespace FashionStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCollectionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Description = c.String(),
                        CategoryParentId = c.Int(nullable: false),
                        Picture = c.String(),
                        Active = c.Boolean(nullable: false),
                        CategoryParent_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Categories", t => t.CategoryParent_CategoryId)
                .Index(t => t.CategoryParent_CategoryId);
            
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        CollectionId = c.Int(nullable: false, identity: true),
                        CollectionName = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Discount = c.Int(nullable: false),
                        DiscountFrom = c.DateTime(nullable: false),
                        DiscountTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CollectionId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.Int(nullable: false),
                        OrderNumber = c.Int(nullable: false),
                        PaymentMethodId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        ShipDate = c.DateTime(nullable: false),
                        RequiredDate = c.DateTime(nullable: false),
                        ShipperId = c.Int(nullable: false),
                        Freight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesTax = c.Single(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        TransactStatus = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Paid = c.Boolean(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId, cascadeDelete: true)
                .ForeignKey("dbo.Shippers", t => t.ShipperId, cascadeDelete: true)
                .Index(t => t.PaymentMethodId)
                .Index(t => t.ShipperId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        PaymentMethodId = c.Int(nullable: false, identity: true),
                        PaymentMethodName = c.String(),
                        Allowed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentMethodId);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ShipperId = c.Int(nullable: false, identity: true),
                        SupplierId = c.Int(nullable: false),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ShipperId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        CategoryId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Size = c.Int(nullable: false),
                        Color = c.String(),
                        Discount = c.Single(nullable: false),
                        UnitsInStock = c.Int(nullable: false),
                        UnitsOnOrder = c.Int(nullable: false),
                        ProductAvailable = c.Boolean(nullable: false),
                        DiscountAvailable = c.Boolean(nullable: false),
                        Picture = c.String(),
                        Ranking = c.Int(nullable: false),
                        Note = c.String(),
                        CollectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Collections", t => t.CollectionId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.SupplierId)
                .Index(t => t.CollectionId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        ContactTitle = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "CollectionId", "dbo.Collections");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ShipperId", "dbo.Shippers");
            DropForeignKey("dbo.Orders", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.Orders", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "CategoryParent_CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CollectionId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Orders", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Orders", new[] { "ShipperId" });
            DropIndex("dbo.Orders", new[] { "PaymentMethodId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Categories", new[] { "CategoryParent_CategoryId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Products");
            DropTable("dbo.Shippers");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Collections");
            DropTable("dbo.Categories");
        }
    }
}
