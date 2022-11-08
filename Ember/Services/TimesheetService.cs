using Ember.DAL;
using Ember.Models;
namespace Ember.Services
{
    public static class TimesheetService
    {
        public static void ClockIn()
        {
            using (var db = new TimeSheetContext())
            {
                db.TimeEntries.Add(new TimeEntry()
                {
                    Time = DateTime.Now,
                    ClockingIn = true
                });
                db.SaveChanges();
            }
        }

        public static void ClockOut()
        {
            using (var db = new TimeSheetContext())
            {
                db.TimeEntries.Add(new TimeEntry()
                {
                    Time = DateTime.Now,
                    ClockingIn = false
                });
                db.SaveChanges();
            }
        }
    }
}
