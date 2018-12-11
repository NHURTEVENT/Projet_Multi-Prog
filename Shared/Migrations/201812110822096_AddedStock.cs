namespace Shared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStock : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockEntries",
                c => new
                    {
                        Ingredient = c.Int(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ingredient, t.ArrivalDate });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StockEntries");
        }
    }
}
