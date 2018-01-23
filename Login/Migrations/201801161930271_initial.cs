namespace WebDBApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                        Hall_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Halls", t => t.Hall_ID)
                .Index(t => t.Hall_ID);
            
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
                        EventType_ID = c.Int(),
                        Trainer_Login = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CalendarEventID)
                .ForeignKey("dbo.EventTypes", t => t.EventType_ID)
                .ForeignKey("dbo.Users", t => t.Trainer_Login, cascadeDelete: true)
                .Index(t => t.EventType_ID)
                .Index(t => t.Trainer_Login);
            
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
                "dbo.GymDetails",
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
                .ForeignKey("dbo.Gyms", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Gyms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SurfaceArea = c.Double(nullable: false),
                        Gym_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gyms", t => t.Gym_ID)
                .Index(t => t.Gym_ID);
            
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
                        User_Login = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_Login)
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
            DropForeignKey("dbo.GymDetails", "ID", "dbo.Gyms");
            DropForeignKey("dbo.Halls", "Gym_ID", "dbo.Gyms");
            DropForeignKey("dbo.Accessories", "Hall_ID", "dbo.Halls");
            DropForeignKey("dbo.CalendarEvents", "Trainer_Login", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.UsersEvents", "CalendarEventID", "dbo.CalendarEvents");
            DropForeignKey("dbo.UsersEvents", "Login", "dbo.Users");
            DropForeignKey("dbo.CalendarEvents", "EventType_ID", "dbo.EventTypes");
            DropIndex("dbo.UsersEvents", new[] { "CalendarEventID" });
            DropIndex("dbo.UsersEvents", new[] { "Login" });
            DropIndex("dbo.Orders", new[] { "User_Login" });
            DropIndex("dbo.OrderDetails", new[] { "ID" });
            DropIndex("dbo.Halls", new[] { "Gym_ID" });
            DropIndex("dbo.GymDetails", new[] { "ID" });
            DropIndex("dbo.Users", new[] { "Role_ID" });
            DropIndex("dbo.CalendarEvents", new[] { "Trainer_Login" });
            DropIndex("dbo.CalendarEvents", new[] { "EventType_ID" });
            DropIndex("dbo.Accessories", new[] { "Hall_ID" });
            DropTable("dbo.UsersEvents");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Halls");
            DropTable("dbo.Gyms");
            DropTable("dbo.GymDetails");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.EventTypes");
            DropTable("dbo.CalendarEvents");
            DropTable("dbo.Accessories");
        }
    }
}
