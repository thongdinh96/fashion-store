namespace FashionStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditCollection : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Collections", "Modified", c => c.DateTime());
            AlterColumn("dbo.Collections", "Discount", c => c.Int());
            AlterColumn("dbo.Collections", "DiscountFrom", c => c.DateTime());
            AlterColumn("dbo.Collections", "DiscountTo", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Collections", "DiscountTo", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Collections", "DiscountFrom", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Collections", "Discount", c => c.Int(nullable: false));
            AlterColumn("dbo.Collections", "Modified", c => c.DateTime(nullable: false));
        }
    }
}
