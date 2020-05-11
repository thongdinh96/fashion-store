namespace FashionStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProductSchema : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CollectionId", "dbo.Collections");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "CollectionId" });
            AlterColumn("dbo.Products", "SupplierId", c => c.Int());
            AlterColumn("dbo.Products", "Size", c => c.Int());
            AlterColumn("dbo.Products", "Discount", c => c.Single());
            AlterColumn("dbo.Products", "UnitsInStock", c => c.Int());
            AlterColumn("dbo.Products", "UnitsOnOrder", c => c.Int());
            AlterColumn("dbo.Products", "Ranking", c => c.Int());
            AlterColumn("dbo.Products", "CollectionId", c => c.Int());
            CreateIndex("dbo.Products", "SupplierId");
            CreateIndex("dbo.Products", "CollectionId");
            AddForeignKey("dbo.Products", "CollectionId", "dbo.Collections", "CollectionId");
            AddForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers", "SupplierId");
            DropColumn("dbo.Products", "DiscountAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "DiscountAvailable", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "CollectionId", "dbo.Collections");
            DropIndex("dbo.Products", new[] { "CollectionId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            AlterColumn("dbo.Products", "CollectionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Ranking", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "UnitsOnOrder", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "UnitsInStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Discount", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "Size", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "SupplierId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CollectionId");
            CreateIndex("dbo.Products", "SupplierId");
            AddForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers", "SupplierId", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CollectionId", "dbo.Collections", "CollectionId", cascadeDelete: true);
        }
    }
}
