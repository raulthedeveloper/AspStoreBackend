namespace AspStoreBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUnitedState : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnitedStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        stateCode = c.String(),
                        stateName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UnitedStates");
        }
    }
}
