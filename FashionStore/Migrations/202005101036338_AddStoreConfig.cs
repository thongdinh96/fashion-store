namespace FashionStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoreConfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreConfigurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NDayNew = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StoreConfigurations");
        }
    }
}
