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
            if (File.Exists("BlockedProgramConfig.txt"))
            {
                File.Delete("BlockedProgramConfig.txt");
            }
            var linesOfProgramsBlackListed = new List<string>();
            await File.WriteAllLinesAsync("BlockedProgramConfig.txt", linesOfProgramsBlackListed);
        }
    }
}
