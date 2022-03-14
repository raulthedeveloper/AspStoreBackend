﻿namespace AspStoreBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcartId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "cartId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "cartId");
        }
    }
}
