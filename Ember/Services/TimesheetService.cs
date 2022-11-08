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

        public static bool GetCurrentClockedInStatus()
        {
            var returnBool = false;
            using (var db = new TimeSheetContext())
            {
                var latestEntry = db.TimeEntries
                       .OrderByDescending(p => p.Time)
                       .FirstOrDefault();
                if (latestEntry != null)
                {
                    returnBool = latestEntry.ClockingIn;
                }
            }
            return returnBool;
        }

        public static TimeSpan GetDailyWorkingTimeForDate(DateTime dateTimeToCheck)
        {
            var returnTimeSpan = new TimeSpan();
            var dateToCheck = dateTimeToCheck.Date;
            var endDateToCheck = dateToCheck.Date.AddDays(1).AddTicks(-1);
            var listOfTimeEntriesDuringAffectiveDate = new List<TimeEntry>();
            using (var db = new TimeSheetContext())
            {
                var rangeOfEntries = db.TimeEntries.Where(te => te.Time >= dateToCheck && te.Time <= endDateToCheck);
                if (rangeOfEntries != null)
                {
                    listOfTimeEntriesDuringAffectiveDate.AddRange(rangeOfEntries.ToList());
                }
            }

            foreach(var timeEntry in listOfTimeEntriesDuringAffectiveDate)
            {
                var nextTimeEntry = GetNextTimeEntry(timeEntry, listOfTimeEntriesDuringAffectiveDate);
                if (nextTimeEntry == null || !timeEntry.ClockingIn || nextTimeEntry.ClockingIn)
                    continue;

                var differenceBetweenEntries = nextTimeEntry.Time - timeEntry.Time;
                returnTimeSpan = returnTimeSpan.Add(differenceBetweenEntries);
            }

            return returnTimeSpan;
        }

        private static TimeEntry? GetNextTimeEntry(TimeEntry previousTimeEntry, List<TimeEntry> timeEntries)
        {
            var latestDate = DateTime.Now.AddDays(1);
            TimeEntry? currentBestTime = null;
            foreach(var entry in timeEntries)
            {
                if (entry.Time <= previousTimeEntry.Time || entry.Time >= latestDate)
                    continue;

                currentBestTime = entry;
                latestDate = entry.Time;
            }
            return currentBestTime;
        }

    }
}
