using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Ember
{
    public partial class EmberOptionsForm : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        public EmberOptionsForm()
        {
            InitializeComponent();
        }

        private void EmberOptionsForm_Load(object sender, EventArgs e)
        {
            var blockedProgramConfigFileName = "BlockedProgramConfig.txt";
            using (StreamWriter sw = File.AppendText(blockedProgramConfigFileName))
            {

            }
            using (StreamReader sr = new StreamReader(blockedProgramConfigFileName))
            {
                listOfBlackListedProgramInput.Text = sr.ReadToEnd();
            }

            var blockedSiteConfigFileName = "BlockedSiteConfig.txt";
            using (StreamWriter sw = File.AppendText(blockedSiteConfigFileName))
            {

            }
            using (StreamReader sr = new StreamReader(blockedSiteConfigFileName))
            {
                listOfBlackListedSites.Text = sr.ReadToEnd();
            }
        }

        private void closeFormButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EmberOptionsForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void EmberOptionsForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void EmberOptionsForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void saveOptionsButton_Click(object sender, EventArgs e)
        {
            SaveAllOptions();
            
        }

        private async void SaveAllOptions()
        {
            var blockedProgramConfigFileName = "BlockedProgramConfig.txt";
            if (File.Exists(blockedProgramConfigFileName))
            {
                File.Delete(blockedProgramConfigFileName);
            }
            var linesOfProgramsBlackListed = new List<string>();
            linesOfProgramsBlackListed.Add(listOfBlackListedProgramInput.Text);
            using (StreamWriter sw = File.AppendText(blockedProgramConfigFileName))
            {
                foreach (var line in linesOfProgramsBlackListed)
                {
                    sw.WriteLine(line);
                }
            }

            var blockedSiteConfigFileName = "BlockedSiteConfig.txt";
            if (File.Exists(blockedSiteConfigFileName))
            {
                File.Delete(blockedSiteConfigFileName);
            }
            var linesOfSiteBlackListed = new List<string>();
            linesOfSiteBlackListed.Add(listOfBlackListedSites.Text);
            using (StreamWriter sw = File.AppendText(blockedSiteConfigFileName))
            {
                foreach (var line in linesOfSiteBlackListed)
                {
                    sw.WriteLine(line);
                }
            }
            Close();
        }
    }
}
