namespace FashionStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvarUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AvarUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AvarUrl");
        }
    }
}
