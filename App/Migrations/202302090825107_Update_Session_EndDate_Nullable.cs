namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Session_EndDate_Nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sessions", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sessions", "EndDate", c => c.DateTime(nullable: false));
        }
    }
}
