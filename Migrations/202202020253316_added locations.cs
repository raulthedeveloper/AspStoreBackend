namespace AspStoreBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlocations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HoursModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        Sunday = c.String(),
                        Monday = c.String(),
                        Tuesday = c.String(),
                        Wednesday = c.String(),
                        Thursday = c.String(),
                        Friday = c.String(),
                        Saturday = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LocationModels", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.LocationModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoursModels", "LocationId", "dbo.LocationModels");
            DropIndex("dbo.HoursModels", new[] { "LocationId" });
            DropTable("dbo.LocationModels");
            DropTable("dbo.HoursModels");
        }
    }
}
