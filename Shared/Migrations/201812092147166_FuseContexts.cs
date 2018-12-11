namespace Shared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FuseContexts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MachineDBEntries",
                c => new
                    {
                        MachineId = c.Int(nullable: false, identity: true),
                        MachineType = c.String(),
                        MaxCapacity = c.Int(nullable: false),
                        MinCapacity = c.Int(nullable: false),
                        RunningTime = c.Int(nullable: false),
                        UnloadingTime = c.Int(nullable: false),
                        LoadingTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MachineId);
            
            CreateTable(
                "dbo.RecipeSteps",
                c => new
                    {
                        Dish = c.Int(nullable: false),
                        Step = c.Int(nullable: false),
                        Name = c.String(),
                        UtensilType = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Dish, t.Step })
                .ForeignKey("dbo.Drawers", t => t.UtensilType, cascadeDelete: true)
                .Index(t => t.UtensilType);
            
            CreateTable(
                "dbo.UtensilEntries",
                c => new
                    {
                        UtensilType = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UtensilType);
            
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
            DropForeignKey("dbo.RecipeSteps", "UtensilType", "dbo.Drawers");
            DropIndex("dbo.RecipeSteps", new[] { "UtensilType" });
            DropTable("dbo.Drawers");
            DropTable("dbo.UtensilEntries");
            DropTable("dbo.RecipeSteps");
            DropTable("dbo.MachineDBEntries");
        }
    }
}
