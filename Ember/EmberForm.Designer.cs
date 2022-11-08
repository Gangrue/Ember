namespace Ember
{
    partial class EmberForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.closeFormButton = new System.Windows.Forms.Button();
            this.ClockedInTimerLabel = new System.Windows.Forms.Label();
            this.ClockedInLabel = new System.Windows.Forms.Label();
            this.ClockInButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // closeFormButton
            // 
            this.closeFormButton.FlatAppearance.BorderSize = 0;
            this.closeFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeFormButton.ForeColor = System.Drawing.Color.White;
            this.closeFormButton.Location = new System.Drawing.Point(163, 12);
            this.closeFormButton.Name = "closeFormButton";
            this.closeFormButton.Size = new System.Drawing.Size(25, 25);
            this.closeFormButton.TabIndex = 0;
            this.closeFormButton.Text = "X";
            this.closeFormButton.UseVisualStyleBackColor = true;
            this.closeFormButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ClockedInTimerLabel
            // 
            this.ClockedInTimerLabel.AutoSize = true;
            this.ClockedInTimerLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.ClockedInTimerLabel.Location = new System.Drawing.Point(12, 171);
            this.ClockedInTimerLabel.Name = "ClockedInTimerLabel";
            this.ClockedInTimerLabel.Size = new System.Drawing.Size(148, 20);
            this.ClockedInTimerLabel.TabIndex = 1;
            this.ClockedInTimerLabel.Text = "ClockedInTimerLabel";
            this.ClockedInTimerLabel.Click += new System.EventHandler(this.ClockedInTimerLabel_Click);
            // 
            // ClockedInLabel
            // 
            this.ClockedInLabel.AutoSize = true;
            this.ClockedInLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.ClockedInLabel.Location = new System.Drawing.Point(12, 151);
            this.ClockedInLabel.Name = "ClockedInLabel";
            this.ClockedInLabel.Size = new System.Drawing.Size(110, 20);
            this.ClockedInLabel.TabIndex = 2;
            this.ClockedInLabel.Text = "ClockedInLabel";
            // 
            // ClockInButton
            // 
            this.ClockInButton.BackColor = System.Drawing.Color.OrangeRed;
            this.ClockInButton.FlatAppearance.BorderSize = 0;
            this.ClockInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClockInButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClockInButton.ForeColor = System.Drawing.SystemColors.Control;
            this.ClockInButton.Location = new System.Drawing.Point(47, 44);
            this.ClockInButton.Margin = new System.Windows.Forms.Padding(0);
            this.ClockInButton.Name = "ClockInButton";
            this.ClockInButton.Size = new System.Drawing.Size(104, 104);
            this.ClockInButton.TabIndex = 3;
            this.ClockInButton.Text = "Clock In";
            this.ClockInButton.UseVisualStyleBackColor = false;
            this.ClockInButton.Click += new System.EventHandler(this.ClockInButton_Click);
            // 
            // EmberForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(200, 200);
            this.Controls.Add(this.ClockInButton);
            this.Controls.Add(this.ClockedInLabel);
            this.Controls.Add(this.ClockedInTimerLabel);
            this.Controls.Add(this.closeFormButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(200, 200);
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "EmberForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ember";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Ember_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EmberForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EmberForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EmberForm_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button closeFormButton;
        private Label ClockedInTimerLabel;
        private Label ClockedInLabel;
        private Button ClockInButton;
    }
}