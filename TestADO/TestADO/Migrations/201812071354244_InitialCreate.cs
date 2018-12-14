namespace TestADO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ustensil",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        dish2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ustensil");
        }
    }
}
