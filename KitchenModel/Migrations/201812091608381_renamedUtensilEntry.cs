namespace Model
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamedUtensilEntry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drawers",
                c => new
                    {
                        UtensilType = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UtensilType);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drawers");
        }
    }
}
