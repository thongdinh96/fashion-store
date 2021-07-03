namespace FashionStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewColumnCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryLevel", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryLevel");
        }
    }
}
