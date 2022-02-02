namespace AspStoreBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        custId = c.Int(nullable: false),
                        prodId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.custId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.prodId, cascadeDelete: true)
                .Index(t => t.custId)
                .Index(t => t.prodId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        first_name = c.String(),
                        last_name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        catId = c.Int(nullable: false),
                        name = c.String(),
                        description = c.String(),
                        image = c.String(),
                        price = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.catId, cascadeDelete: true)
                .Index(t => t.catId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        image = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        prodId = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.prodId, cascadeDelete: true)
                .Index(t => t.prodId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "prodId", "dbo.Products");
            DropForeignKey("dbo.Carts", "prodId", "dbo.Products");
            DropForeignKey("dbo.Products", "catId", "dbo.Categories");
            DropForeignKey("dbo.Carts", "custId", "dbo.Customers");
            DropIndex("dbo.Sales", new[] { "prodId" });
            DropIndex("dbo.Products", new[] { "catId" });
            DropIndex("dbo.Carts", new[] { "prodId" });
            DropIndex("dbo.Carts", new[] { "custId" });
            DropTable("dbo.Sales");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
            DropTable("dbo.Carts");
        }
    }
}
