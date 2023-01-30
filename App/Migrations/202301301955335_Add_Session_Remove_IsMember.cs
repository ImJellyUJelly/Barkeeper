namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Session_Remove_IsMember : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsEvent = c.Boolean(nullable: false),
                        EventDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "EventPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Orders", "IsMember");
            DropColumn("dbo.Products", "MemberPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "MemberPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "IsMember", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "EventPrice");
            DropTable("dbo.Sessions");
        }
    }
}
