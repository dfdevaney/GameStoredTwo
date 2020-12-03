namespace GameStoredTwo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
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
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        GameTitle = c.String(nullable: false),
                        UserID = c.Guid(),
                        ConsoleID = c.Int(),
                        PublisherID = c.Int(),
                        DeveloperID = c.Int(),
                        Description = c.String(),
                        ReleaseDate = c.String(),
                        AddToFavoriteGames = c.Boolean(nullable: false),
                        AddToWishlist = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.Console", t => t.ConsoleID)
                .ForeignKey("dbo.Developer", t => t.DeveloperID)
                .ForeignKey("dbo.Publisher", t => t.PublisherID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.ConsoleID)
                .Index(t => t.PublisherID)
                .Index(t => t.DeveloperID);
            
            CreateTable(
                "dbo.Developer",
                c => new
                    {
                        DeveloperID = c.Int(nullable: false, identity: true),
                        DeveloperName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DeveloperID);
            
            CreateTable(
                "dbo.GameListOfDevelopers",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        GameTitle = c.String(),
                        Developer_DeveloperID = c.Int(),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.Developer", t => t.Developer_DeveloperID)
                .Index(t => t.Developer_DeveloperID);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        PublisherID = c.Int(nullable: false, identity: true),
                        PublisherName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PublisherID);
            
            CreateTable(
                "dbo.GameListOfPublishers",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        GameTitle = c.String(),
                        Publisher_PublisherID = c.Int(),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.Publisher", t => t.Publisher_PublisherID)
                .Index(t => t.Publisher_PublisherID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.FavoriteGames",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        GameTitle = c.String(),
                        User_UserID = c.Guid(),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.User", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Wishlist",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        GameTitle = c.String(),
                        User_UserID = c.Guid(),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.User", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.ConsoleListOfGames",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        GameTitle = c.String(),
                        Console_ConsoleID = c.Int(),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.Console", t => t.Console_ConsoleID)
                .Index(t => t.Console_ConsoleID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.ConsoleListOfGames", "Console_ConsoleID", "dbo.Console");
            DropForeignKey("dbo.Game", "UserID", "dbo.User");
            DropForeignKey("dbo.Wishlist", "User_UserID", "dbo.User");
            DropForeignKey("dbo.FavoriteGames", "User_UserID", "dbo.User");
            DropForeignKey("dbo.Game", "PublisherID", "dbo.Publisher");
            DropForeignKey("dbo.GameListOfPublishers", "Publisher_PublisherID", "dbo.Publisher");
            DropForeignKey("dbo.Game", "DeveloperID", "dbo.Developer");
            DropForeignKey("dbo.GameListOfDevelopers", "Developer_DeveloperID", "dbo.Developer");
            DropForeignKey("dbo.Game", "ConsoleID", "dbo.Console");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.ConsoleListOfGames", new[] { "Console_ConsoleID" });
            DropIndex("dbo.Wishlist", new[] { "User_UserID" });
            DropIndex("dbo.FavoriteGames", new[] { "User_UserID" });
            DropIndex("dbo.GameListOfPublishers", new[] { "Publisher_PublisherID" });
            DropIndex("dbo.GameListOfDevelopers", new[] { "Developer_DeveloperID" });
            DropIndex("dbo.Game", new[] { "DeveloperID" });
            DropIndex("dbo.Game", new[] { "PublisherID" });
            DropIndex("dbo.Game", new[] { "ConsoleID" });
            DropIndex("dbo.Game", new[] { "UserID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.ConsoleListOfGames");
            DropTable("dbo.Wishlist");
            DropTable("dbo.FavoriteGames");
            DropTable("dbo.User");
            DropTable("dbo.GameListOfPublishers");
            DropTable("dbo.Publisher");
            DropTable("dbo.GameListOfDevelopers");
            DropTable("dbo.Developer");
            DropTable("dbo.Game");
            DropTable("dbo.Console");
        }
    }
}
