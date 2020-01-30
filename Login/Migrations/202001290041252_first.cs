namespace WebDBApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Room_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rooms", t => t.Room_ID)
                .Index(t => t.Room_ID);
            
            CreateTable(
                "dbo.BuildingDetails",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Address = c.String(),
                        ContactPhone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Buildings", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SurfaceArea = c.Double(nullable: false),
                        Building_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Buildings", t => t.Building_ID)
                .Index(t => t.Building_ID);
            
            CreateTable(
                "dbo.CalendarEvents",
                c => new
                    {
                        CalendarEventID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        StartAt = c.DateTime(nullable: false),
                        EndAt = c.DateTime(nullable: false),
                        IsFullDay = c.Boolean(nullable: false),
                        Building_ID = c.Int(nullable: false),
                        EventType_ID = c.Int(),
                        Owner_Login = c.String(nullable: false, maxLength: 128),
                        Room_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CalendarEventID)
                .ForeignKey("dbo.Buildings", t => t.Building_ID, cascadeDelete: true)
                .ForeignKey("dbo.EventTypes", t => t.EventType_ID)
                .ForeignKey("dbo.Users", t => t.Owner_Login, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.Room_ID, cascadeDelete: true)
                .Index(t => t.Building_ID)
                .Index(t => t.EventType_ID)
                .Index(t => t.Owner_Login)
                .Index(t => t.Room_ID);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Login = c.String(nullable: false, maxLength: 128),
                        Created = c.DateTime(nullable: false),
                        Password = c.String(nullable: false),
                        PasswordCreated = c.DateTime(nullable: false),
                        Salt = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Sex = c.Boolean(nullable: false),
                        IsFrozen = c.Boolean(nullable: false),
                        Role_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Login)
                .ForeignKey("dbo.Roles", t => t.Role_ID, cascadeDelete: true)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Amount = c.Int(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        IsRejected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                        Room_ID = c.Int(nullable: false),
                        User_Login = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rooms", t => t.Room_ID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Login)
                .Index(t => t.Room_ID)
                .Index(t => t.User_Login);
            
            CreateTable(
                "dbo.UsersEvents",
                c => new
                    {
                        Login = c.String(nullable: false, maxLength: 128),
                        CalendarEventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Login, t.CalendarEventID })
                .ForeignKey("dbo.Users", t => t.Login)
                .ForeignKey("dbo.CalendarEvents", t => t.CalendarEventID)
                .Index(t => t.Login)
                .Index(t => t.CalendarEventID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "User_Login", "dbo.Users");
            DropForeignKey("dbo.Orders", "Room_ID", "dbo.Rooms");
            DropForeignKey("dbo.CalendarEvents", "Room_ID", "dbo.Rooms");
            DropForeignKey("dbo.CalendarEvents", "Owner_Login", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.UsersEvents", "CalendarEventID", "dbo.CalendarEvents");
            DropForeignKey("dbo.UsersEvents", "Login", "dbo.Users");
            DropForeignKey("dbo.CalendarEvents", "EventType_ID", "dbo.EventTypes");
            DropForeignKey("dbo.CalendarEvents", "Building_ID", "dbo.Buildings");
            DropForeignKey("dbo.BuildingDetails", "ID", "dbo.Buildings");
            DropForeignKey("dbo.Rooms", "Building_ID", "dbo.Buildings");
            DropForeignKey("dbo.Accessories", "Room_ID", "dbo.Rooms");
            DropIndex("dbo.UsersEvents", new[] { "CalendarEventID" });
            DropIndex("dbo.UsersEvents", new[] { "Login" });
            DropIndex("dbo.Orders", new[] { "User_Login" });
            DropIndex("dbo.Orders", new[] { "Room_ID" });
            DropIndex("dbo.OrderDetails", new[] { "ID" });
            DropIndex("dbo.Users", new[] { "Role_ID" });
            DropIndex("dbo.CalendarEvents", new[] { "Room_ID" });
            DropIndex("dbo.CalendarEvents", new[] { "Owner_Login" });
            DropIndex("dbo.CalendarEvents", new[] { "EventType_ID" });
            DropIndex("dbo.CalendarEvents", new[] { "Building_ID" });
            DropIndex("dbo.Rooms", new[] { "Building_ID" });
            DropIndex("dbo.BuildingDetails", new[] { "ID" });
            DropIndex("dbo.Accessories", new[] { "Room_ID" });
            DropTable("dbo.UsersEvents");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.EventTypes");
            DropTable("dbo.CalendarEvents");
            DropTable("dbo.Rooms");
            DropTable("dbo.Buildings");
            DropTable("dbo.BuildingDetails");
            DropTable("dbo.Accessories");
        }
    }
}
