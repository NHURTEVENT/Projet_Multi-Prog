namespace Shared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMachineType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MachineDBEntries", "MachineType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MachineDBEntries", "MachineType", c => c.String());
        }
    }
}
