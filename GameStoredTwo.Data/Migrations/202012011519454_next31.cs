namespace GameStoredTwo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class next31 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Game", name: "User_UserID", newName: "UserID");
            RenameIndex(table: "dbo.Game", name: "IX_User_UserID", newName: "IX_UserID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Game", name: "IX_UserID", newName: "IX_User_UserID");
            RenameColumn(table: "dbo.Game", name: "UserID", newName: "User_UserID");
        }
    }
}
