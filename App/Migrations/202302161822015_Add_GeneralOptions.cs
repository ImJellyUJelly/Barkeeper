namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_GeneralOptions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GeneralOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductButtonSize = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GeneralOptions");
        }
    }
}
