namespace Model
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedStructure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeSteps",
                c => new
                    {
                        Dish = c.Int(nullable: false),
                        Step = c.Int(nullable: false),
                        Name = c.String(),
                        Utensil = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Dish, t.Step })
                .ForeignKey("dbo.UtensilEntries", t => t.Utensil, cascadeDelete: true)
                .Index(t => t.Utensil);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeSteps", "Utensil", "dbo.UtensilEntries");
            DropIndex("dbo.RecipeSteps", new[] { "Utensil" });
            DropTable("dbo.RecipeSteps");
        }
    }
}
