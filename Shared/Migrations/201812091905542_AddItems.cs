namespace Shared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemDBEntries",
                c => new
                    {
                        ItemType = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemType);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ItemDBEntries");
        }
    }
}
