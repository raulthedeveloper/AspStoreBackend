namespace AspStoreBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtimestamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CreatedAt");
            DropColumn("dbo.Products", "CreatedAt");
            DropColumn("dbo.Customers", "CreatedAt");
            DropColumn("dbo.Carts", "CreatedAt");
        }
    }
}
