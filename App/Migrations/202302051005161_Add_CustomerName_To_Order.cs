namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_CustomerName_To_Order : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CustomerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CustomerName");
        }
    }
}
