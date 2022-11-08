namespace Ember.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedIdForTimeLogSecondTry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TimeEntries",
                c => new
                    {
                        TimeEntryID = c.Int(nullable: false, identity: true),
                        ClockingIn = c.Boolean(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TimeEntryID);
            
            DropTable("dbo.TimeLogs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TimeLogs",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ClockingIn = c.Boolean(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.TimeEntries");
        }
    }
}
