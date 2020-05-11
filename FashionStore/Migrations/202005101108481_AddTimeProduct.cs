namespace FashionStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "Modified", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Modified");
            DropColumn("dbo.Products", "Created");
        }
    }
}
