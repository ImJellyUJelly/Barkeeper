namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Start_And_EndDate_Session_Remove_IsEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sessions", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sessions", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Sessions", "IsEvent");
            DropColumn("dbo.Sessions", "EventDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sessions", "EventDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sessions", "IsEvent", c => c.Boolean(nullable: false));
            DropColumn("dbo.Sessions", "EndDate");
            DropColumn("dbo.Sessions", "StartDate");
        }
    }
}
