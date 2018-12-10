namespace Shared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedFuseContexts2 : DbMigration
    {
        public override void Up()
        {/*
            RenameColumn(table: "dbo.RecipeSteps", name: "Utensil", newName: "UtensilType");
            RenameIndex(table: "dbo.RecipeSteps", name: "IX_Utensil", newName: "IX_UtensilType");
        */}
        
        public override void Down()
        {/*
            RenameIndex(table: "dbo.RecipeSteps", name: "IX_UtensilType", newName: "IX_Utensil");
            RenameColumn(table: "dbo.RecipeSteps", name: "UtensilType", newName: "Utensil");
        */}
    }
}
