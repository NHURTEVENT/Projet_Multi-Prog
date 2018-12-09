namespace Shared.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TableDBEntries",
                c => new
                    {
                        Square = c.Int(nullable: false),
                        Row = c.Int(nullable: false),
                        Column = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Square, t.Row, t.Column });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TableDBEntries");
        }
    }
}
