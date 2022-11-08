namespace Ember.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedIdForTimeLog : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TimeLogs");
            AddColumn("dbo.TimeLogs", "ID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.TimeLogs", "ID");
            DropColumn("dbo.TimeLogs", "TimeLogId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeLogs", "TimeLogId", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.TimeLogs");
            DropColumn("dbo.TimeLogs", "ID");
            AddPrimaryKey("dbo.TimeLogs", "TimeLogId");
        }
    }
}
