namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_IsMember_To_Member : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsMember", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsMember");
        }
    }
}
