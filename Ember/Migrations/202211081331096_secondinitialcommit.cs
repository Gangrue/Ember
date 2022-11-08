namespace Ember.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondinitialcommit : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TimeLogs");
            AddColumn("dbo.TimeLogs", "TimeLogId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.TimeLogs", "TimeLogId");
            DropColumn("dbo.TimeLogs", "Id");
            DropColumn("dbo.TimeLogs", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeLogs", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.TimeLogs", "Id", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.TimeLogs");
            DropColumn("dbo.TimeLogs", "TimeLogId");
            AddPrimaryKey("dbo.TimeLogs", "Id");
        }
    }
}
