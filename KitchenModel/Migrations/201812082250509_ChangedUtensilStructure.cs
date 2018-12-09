namespace Model
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUtensilStructure : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UtensilEntries");
            AddColumn("dbo.UtensilEntries", "UtensilType", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UtensilEntries", "UtensilType");
            DropColumn("dbo.UtensilEntries", "Utensil");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UtensilEntries", "Utensil", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.UtensilEntries");
            DropColumn("dbo.UtensilEntries", "UtensilType");
            AddPrimaryKey("dbo.UtensilEntries", "Utensil");
        }
    }
}
