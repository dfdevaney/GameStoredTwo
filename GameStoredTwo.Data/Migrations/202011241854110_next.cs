namespace GameStoredTwo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class next : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Console",
                c => new
                    {
                        ConsoleID = c.Int(nullable: false, identity: true),
                        ConsoleName = c.String(nullable: false),
                        ConsoleDescription = c.String(),
                    })
                .PrimaryKey(t => t.ConsoleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Console");
        }
    }
}
