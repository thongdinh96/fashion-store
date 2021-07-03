namespace FashionStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        SizeName = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SizeName, t.ProductId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            DropColumn("dbo.Products", "Size");
            AlterColumn("dbo.Products", "Ranking", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Size", c => c.Int());
            DropForeignKey("dbo.Sizes", "ProductId", "dbo.Products");
            DropIndex("dbo.Sizes", new[] { "ProductId" });
            DropTable("dbo.Sizes");
        }
    }
}
