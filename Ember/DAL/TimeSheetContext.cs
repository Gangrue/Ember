using Ember.Models;
using System.Data.Entity;

namespace Ember.DAL
{
    public class TimeSheetContext : DbContext
    {
        public TimeSheetContext() : base("name=EmberDatabaseConnectionString")
        {

        }
        public DbSet<TimeEntry> TimeEntries { get; set; }
    }
}
