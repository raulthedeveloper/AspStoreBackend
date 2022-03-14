namespace AspStoreBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartIdtostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carts", "cartId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carts", "cartId", c => c.Int(nullable: false));
        }
    }
}
