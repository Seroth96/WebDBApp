namespace WebDBApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CalendarEvents", "Building_ID", "dbo.Buildings");
            DropForeignKey("dbo.CalendarEvents", "Room_ID", "dbo.Rooms");
            DropIndex("dbo.CalendarEvents", new[] { "Building_ID" });
            DropIndex("dbo.CalendarEvents", new[] { "Room_ID" });
            AlterColumn("dbo.CalendarEvents", "Building_ID", c => c.Int());
            AlterColumn("dbo.CalendarEvents", "Room_ID", c => c.Int());
            CreateIndex("dbo.CalendarEvents", "Building_ID");
            CreateIndex("dbo.CalendarEvents", "Room_ID");
            AddForeignKey("dbo.CalendarEvents", "Building_ID", "dbo.Buildings", "ID");
            AddForeignKey("dbo.CalendarEvents", "Room_ID", "dbo.Rooms", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CalendarEvents", "Room_ID", "dbo.Rooms");
            DropForeignKey("dbo.CalendarEvents", "Building_ID", "dbo.Buildings");
            DropIndex("dbo.CalendarEvents", new[] { "Room_ID" });
            DropIndex("dbo.CalendarEvents", new[] { "Building_ID" });
            AlterColumn("dbo.CalendarEvents", "Room_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.CalendarEvents", "Building_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.CalendarEvents", "Room_ID");
            CreateIndex("dbo.CalendarEvents", "Building_ID");
            AddForeignKey("dbo.CalendarEvents", "Room_ID", "dbo.Rooms", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CalendarEvents", "Building_ID", "dbo.Buildings", "ID", cascadeDelete: true);
        }
    }
}
