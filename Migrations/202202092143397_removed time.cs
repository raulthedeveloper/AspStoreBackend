namespace AspStoreBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedtime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carts", "CreatedAt");
            DropColumn("dbo.Customers", "CreatedAt");
            DropColumn("dbo.Products", "CreatedAt");
            DropColumn("dbo.Categories", "CreatedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Carts", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
