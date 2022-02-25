namespace AspStoreBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedlocationtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LocationModels", "city", c => c.String());
            AddColumn("dbo.LocationModels", "state", c => c.String());
            AddColumn("dbo.LocationModels", "postalCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LocationModels", "postalCode");
            DropColumn("dbo.LocationModels", "state");
            DropColumn("dbo.LocationModels", "city");
        }
    }
}
