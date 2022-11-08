using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Automation;
using Timer = System.Windows.Forms.Timer;
using System.Runtime.InteropServices;
using Ember.Services;

namespace Ember
{
    public partial class EmberForm : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public bool AutoClockedIn;
        public bool ClockedIn;
        public TimeSpan ClockedInTime;
        public EmberForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ClockedIn || AutoClockedIn)
            {
                TimesheetService.ClockOut();
            }
            Close();
        }

        private void Ember_Load(object sender, EventArgs e)
        {
            ClockedIn = TimesheetService.GetCurrentClockedInStatus();
            AutoClockedIn = ClockedIn;
            ClockedInTime = TimesheetService.GetDailyWorkingTimeForDate(DateTime.Now);
            StartProcessCheckingTimer();
            StartFastUpdateTimer();
            UpdateVisualsOnForm();
        }

        private void StartFastUpdateTimer()
        {
            Timer MyTimer = new Timer();
            MyTimer.Interval = (1 * 1000); // 1 seconds
            MyTimer.Tick += new EventHandler(FastCheckTimerTick);
            MyTimer.Start();
        }
        private void StartProcessCheckingTimer()
        {
            Timer MyTimer = new Timer();
            MyTimer.Interval = (10 * 1000); // 10 seconds
            MyTimer.Tick += new EventHandler(ProcessCheckTimerTick);
            MyTimer.Start();
        }
        private void FastCheckTimerTick(object sender, EventArgs e)
        {
            bool theDudeIsWorking = AutoClockedIn;
            var inactiveTime = GetInactiveTime();
            var inactiveTimeMax = new TimeSpan(0, 0, 0, 0, 60 * 1000);
            if (inactiveTime != null && inactiveTime >= inactiveTimeMax)
                theDudeIsWorking = false;

            if (theDudeIsWorking)
                ClockedInTime = ClockedInTime.Add(new TimeSpan(0, 0, 1));

            UpdateClockedStatus(theDudeIsWorking);
            UpdateVisualsOnForm();
        }
        private void ProcessCheckTimerTick(object sender, EventArgs e)
        {
            bool theDudeIsWorking = CheckForLoserChromeTabs();
            if (theDudeIsWorking)
            {
                theDudeIsWorking = CheckForGamerTabs();
            }
            if (theDudeIsWorking)
            {
                theDudeIsWorking = CheckForBlacklistedTabs();
            }
            var inactiveTime = GetInactiveTime();
            var inactiveTimeMax = new TimeSpan(0,0,0,0,60*1000);
            if (inactiveTime != null && inactiveTime >= inactiveTimeMax)
                theDudeIsWorking = false;
            UpdateClockedStatus(theDudeIsWorking);
            UpdateVisualsOnForm();
        }

        private bool CheckForBlacklistedTabs()
        {
            var listOfLoserTabs = new List<string>()
            {
                "steam",
                "discord"
            };
            var listOfAllProcesses = Process.GetProcesses();
            foreach(var proc in listOfAllProcesses)
            {
                var procName = proc?.ProcessName?.ToLower();
                if (procName == null)
                    continue;

                foreach (var blacklistTab in listOfLoserTabs)
                {
                    if (procName.Contains(blacklistTab.ToLower()))
                        return false;
                }
            }

            return true;
        }

        private void UpdateClockedStatus(bool isWorking)
        {
            var previousClockedStatus = AutoClockedIn;
            if (isWorking && ClockedIn)
            {
                AutoClockedIn = true;
                if (previousClockedStatus != AutoClockedIn)
                {
                    TimesheetService.ClockIn();
                }
                return;
            }
            AutoClockedIn = false;
            if (previousClockedStatus != AutoClockedIn)
            {
                TimesheetService.ClockOut();
            }
        }

        private bool CheckForGamerTabs()
        {
            Process[] procsSteam = Process.GetProcessesByName("steam");

            if (procsSteam.Length <= 0)
                return true;

            return false;
        }

        private bool CheckForLoserChromeTabs()
        {
            Process[] procsChrome = Process.GetProcessesByName("chrome");

            if (procsChrome.Length <= 0)
                return true;
            var isWorking = true;
            foreach (Process proc in procsChrome)
            {
                var processName = GetProcessServiceName(proc);
                if (processName == null)
                    continue;
                isWorking = CompareProcessNameToListOfBlackListSites(processName);
                if (!isWorking)
                    return false;
            }
            return isWorking;
        }
        private void UpdateVisualsOnForm()
        {
            //This is the real clocked in
            if (AutoClockedIn)
            {
                ClockedInLabel.Text = "Clocked In";
                ClockedInLabel.ForeColor = Color.GreenYellow;
            }
            else
            {
                ClockedInLabel.Text = "Clocked Out";
                ClockedInLabel.ForeColor = Color.OrangeRed;
            }
            //this is the manual clocked in... This one is not respected if user is inactive
            if (ClockedIn)
            {
                ClockInButton.BackColor = Color.Green;
                ClockInButton.Text = "Clocked In";
            }
            else
            {
                ClockInButton.BackColor = Color.Red;
                ClockInButton.Text = "Clocked Out";
            }
            ClockedInTimerLabel.Text = "Clocked in for: " + ClockedInTime.Hours + ":" + ClockedInTime.Minutes + ":" + ClockedInTime.Seconds;
        }
        private bool CompareProcessNameToListOfBlackListSites(string nameOfSite)
        {
            var listOfLoserSites = new List<string>()
            {
                "youtube",
                "youtu.be",
                "twitter",
                "facebook",
                "itch.io",
                "chess"
            };

            foreach (var site in listOfLoserSites)
            {
                if (nameOfSite.ToLower().Contains(site.ToLower()))
                    return false;
            }

            return true;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);


        public static TimeSpan? GetInactiveTime()
        {
            LASTINPUTINFO info = new LASTINPUTINFO();
            info.cbSize = (uint)Marshal.SizeOf(info);
            if (GetLastInputInfo(ref info))
                return TimeSpan.FromMilliseconds(Environment.TickCount - info.dwTime);
            else
                return null;
        }

        private string? GetProcessServiceName(Process proc)
        {                
            if (proc.MainWindowHandle == IntPtr.Zero)
                return null;

            AutomationElement root = AutomationElement.FromHandle(proc.MainWindowHandle);
            var SearchBar = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "Address and search bar"));
            if (SearchBar != null)
                return (string)SearchBar.GetCurrentPropertyValue(ValuePatternIdentifiers.ValueProperty);

            return null;
        }

        private void EmberForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void EmberForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void EmberForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void ClockedInTimerLabel_Click(object sender, EventArgs e)
        {

        }

        private void ClockInButton_Click(object sender, EventArgs e)
        {
            ClockedIn = !ClockedIn;
            UpdateVisualsOnForm();
        }
    }
}