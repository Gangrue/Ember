using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ember.Models
{
    public class TimeEntry
    {
        public int TimeEntryID { get; set; }
        public bool ClockingIn { get; set; }
        public DateTime Time { get; set; }
    }
}
