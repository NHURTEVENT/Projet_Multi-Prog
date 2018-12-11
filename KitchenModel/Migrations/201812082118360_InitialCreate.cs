namespace Model
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                "dbo.UtensilEntries",
                c => new
                    {
                        Utensil = c.String(nullable: false, maxLength: 128),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Utensil);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UtensilEntries");
            DropTable("dbo.MachineDBEntries");
        }
    }
}
