namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Models : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Coins", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Coins", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "PayMethod", c => c.Int(nullable: false));
            AddColumn("dbo.Revenues", "PayMethod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Revenues", "PayMethod");
            DropColumn("dbo.Orders", "PayMethod");
            DropColumn("dbo.Orders", "Coins");
            DropColumn("dbo.OrderDetails", "Coins");
        }
    }
}
