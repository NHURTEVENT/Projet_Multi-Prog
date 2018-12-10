namespace Shared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedFuseContexts : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UtensilEntries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UtensilEntries",
                c => new
                    {
                        UtensilType = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UtensilType);
            
        }
    }
}
