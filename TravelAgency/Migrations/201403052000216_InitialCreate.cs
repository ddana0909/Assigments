namespace TravelAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Legs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartLocation = c.String(nullable: false),
                        FinishLocation = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        TripId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trips", t => t.TripId, cascadeDelete: true)
                .Index(t => t.TripId);
            
            CreateTable(
                "dbo.GuestRegistrations",
                c => new
                    {
                        GuestRegistrationId = c.Int(nullable: false, identity: true),
                        LegId = c.Int(nullable: false),
                        GuestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GuestRegistrationId)
                .ForeignKey("dbo.Legs", t => t.LegId, cascadeDelete: true)
                .ForeignKey("dbo.Guests", t => t.GuestId, cascadeDelete: true)
                .Index(t => t.LegId)
                .Index(t => t.GuestId);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        MinimumGuests = c.Int(nullable: false),
                        Viable = c.Boolean(nullable: false),
                        Complete = c.Boolean(nullable: false),
                        PicturePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.GuestRegistrations", new[] { "GuestId" });
            DropIndex("dbo.GuestRegistrations", new[] { "LegId" });
            DropIndex("dbo.Legs", new[] { "TripId" });
            DropForeignKey("dbo.GuestRegistrations", "GuestId", "dbo.Guests");
            DropForeignKey("dbo.GuestRegistrations", "LegId", "dbo.Legs");
            DropForeignKey("dbo.Legs", "TripId", "dbo.Trips");
            DropTable("dbo.Trips");
            DropTable("dbo.Guests");
            DropTable("dbo.GuestRegistrations");
            DropTable("dbo.Legs");
        }
    }
}
