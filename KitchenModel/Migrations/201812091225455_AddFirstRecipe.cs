namespace Model
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFirstRecipe : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UtensilEntries");
            CreateTable(
                "dbo.RecipeSteps",
                c => new
                    {
                        Dish = c.Int(nullable: false),
                        Step = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                        UtensilType = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Dish, t.Step })
                .ForeignKey("dbo.UtensilEntries", t => t.UtensilType, cascadeDelete: true)
                .Index(t => t.UtensilType);
            
            //AddColumn("dbo.UtensilEntries", "UtensilType", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UtensilEntries", "UtensilType");
            //DropColumn("dbo.UtensilEntries", "Utensil");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UtensilEntries", "Utensil", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.RecipeSteps", "Utensil", "dbo.UtensilEntries");
            DropIndex("dbo.RecipeSteps", new[] { "Utensil" });
            DropPrimaryKey("dbo.UtensilEntries");
            DropColumn("dbo.UtensilEntries", "UtensilType");
            DropTable("dbo.RecipeSteps");
            AddPrimaryKey("dbo.UtensilEntries", "Utensil");
        }
    }
}
