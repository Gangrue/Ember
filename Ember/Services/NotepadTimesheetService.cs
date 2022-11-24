using Ember.Models;
using System.Globalization;
using System.IO;

namespace Ember.Services
{
    public static class NotepadTimesheetService
    {
        public static void CreateDirectoriesIfDoNotExist()
        {
            System.IO.Directory.CreateDirectory("logs");
        }
        public static string[] GetAllBlackListedPrograms()
        {
            var blockedProgramConfigFileName = "BlockedProgramConfig.txt";
            using (StreamWriter sw = File.AppendText(blockedProgramConfigFileName))
            {

            }
            using (StreamReader sr = new StreamReader(blockedProgramConfigFileName))
            {
                var longString = sr.ReadToEnd();
                string[] lines = longString.Split(
                    new string[] { Environment.NewLine, "," },
                    StringSplitOptions.None
                );
                return lines;
            }
        }
        public static string[] GetAllBlackListedSites()
        {
            var blockedSitesConfigFileName = "BlockedSiteConfig.txt";
            using (StreamWriter sw = File.AppendText(blockedSitesConfigFileName))
            {

            }
            using (StreamReader sr = new StreamReader(blockedSitesConfigFileName))
            {
                var longString = sr.ReadToEnd();
                string[] lines = longString.Split(
                    new string[] { Environment.NewLine, "," },
                    StringSplitOptions.None
                );
                return lines;
            }
        }

        public static void GenerateDailyReportFile()
        {
            var listOfDaysWorked = new List<string>();
            foreach (string file in Directory.EnumerateFiles("logs", "*.txt"))
            {
                var fileName = Path.GetFileName(file);
                var dateStringToCheck = fileName.Split('.')?.FirstOrDefault();
                if (dateStringToCheck == null) continue;
                var dateToCheck = DateTime.ParseExact(dateStringToCheck, "yyyyMMdd",CultureInfo.InvariantCulture);
                var timeForDay = GetDailyWorkingTimeForDate(dateToCheck);
                listOfDaysWorked.Add("Date: " + dateStringToCheck + ", Time spent working: " + timeForDay);
            }
            using (StreamWriter sw = File.AppendText("DailyReport.txt"))
            {

            }
            FileInfo fi = new FileInfo("DailyReport.txt");
            using (TextWriter txtWriter = new StreamWriter(fi.Open(FileMode.Truncate)))
            {
                txtWriter.WriteLine("Here is a list of all days worked:");
                foreach(string line in listOfDaysWorked)
                {
                    txtWriter.WriteLine(line);
                }
            }
        }

        public static void ClockIn()
        {
            var todaysClockInFileName = "logs/" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            if (!File.Exists(todaysClockInFileName))
            {
                File.Create(todaysClockInFileName);
            }
            File.AppendAllText(todaysClockInFileName, "TRUE," +
                   DateTime.Now.ToString() + Environment.NewLine);
        }

        public static void ClockOut()
        {
            var todaysClockInFileName = "logs/" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            if (!File.Exists(todaysClockInFileName))
            {
                File.Create(todaysClockInFileName);
            }
            File.AppendAllText(todaysClockInFileName, "FALSE," +
                   DateTime.Now.ToString() + Environment.NewLine);
        }

        public static bool GetCurrentClockedInStatus()
        {
            var returnBool = false;
            var todaysClockInFileName = "logs/" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            using (StreamWriter sw = File.AppendText(todaysClockInFileName))
            {

            }
            var lastLine = File.ReadLines(todaysClockInFileName)?.LastOrDefault();
            var clockedInAlready = lastLine?.Split(',')?.First();
            returnBool = (clockedInAlready == "TRUE");
            return returnBool;
        }

        public static TimeSpan GetDailyWorkingTimeForDate(DateTime dateTimeToCheck)
        {
            var returnTimeSpan = new TimeSpan();
            var dateToCheck = dateTimeToCheck.Date;
            var listOfTimeEntriesDuringAffectiveDate = new List<TimeEntry>();
            var clockInFileName = "logs/" + dateToCheck.ToString("yyyyMMdd") + ".txt";
            if (!File.Exists(clockInFileName))
            {
                File.Create(clockInFileName);
            }
            var lines = File.ReadLines(clockInFileName);
            foreach (var line in lines)
            {
                var splitLines = line.Split(',');
                var dateTimeString = splitLines?[1];
                var clockingIn = (splitLines?[0] == "TRUE");
                if (dateTimeString == null)
                    continue;

                var newTimeEntryToAddToList = new TimeEntry();
                newTimeEntryToAddToList.Time = DateTime.Parse(dateTimeString);
                newTimeEntryToAddToList.ClockingIn = clockingIn;
                listOfTimeEntriesDuringAffectiveDate.Add(newTimeEntryToAddToList);
            }

            foreach (var timeEntry in listOfTimeEntriesDuringAffectiveDate)
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
            foreach (var entry in timeEntries)
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
