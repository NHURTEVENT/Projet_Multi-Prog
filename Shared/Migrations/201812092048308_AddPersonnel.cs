namespace Shared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonnel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonnelDBEntries",
                c => new
                    {
                        PersonnelType = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonnelType);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PersonnelDBEntries");
        }
    }
}
