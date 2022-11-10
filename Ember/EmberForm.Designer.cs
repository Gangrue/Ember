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
            this.ClockInButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // closeFormButton
            // 
            this.closeFormButton.FlatAppearance.BorderSize = 0;
            this.closeFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeFormButton.ForeColor = System.Drawing.Color.White;
            this.closeFormButton.Location = new System.Drawing.Point(176, 0);
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
            this.ClockedInTimerLabel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ClockedInTimerLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.ClockedInTimerLabel.Location = new System.Drawing.Point(45, 9);
            this.ClockedInTimerLabel.Name = "ClockedInTimerLabel";
            this.ClockedInTimerLabel.Size = new System.Drawing.Size(74, 21);
            this.ClockedInTimerLabel.TabIndex = 1;
            this.ClockedInTimerLabel.Text = "00:00:00";
            this.ClockedInTimerLabel.Click += new System.EventHandler(this.ClockedInTimerLabel_Click);
            // 
            // ClockInButton
            // 
            this.ClockInButton.BackColor = System.Drawing.Color.Transparent;
            this.ClockInButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ClockInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClockInButton.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClockInButton.ForeColor = System.Drawing.SystemColors.Control;
            this.ClockInButton.Image = global::Ember.Properties.Resources.SmotheredAnimation;
            this.ClockInButton.Location = new System.Drawing.Point(9, 41);
            this.ClockInButton.Margin = new System.Windows.Forms.Padding(0);
            this.ClockInButton.Name = "ClockInButton";
            this.ClockInButton.Size = new System.Drawing.Size(150, 150);
            this.ClockInButton.TabIndex = 3;
            this.ClockInButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ClockInButton.UseVisualStyleBackColor = false;
            this.ClockInButton.Click += new System.EventHandler(this.ClockInButton_Click);
            // 
            // EmberForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(200, 200);
            this.Controls.Add(this.ClockInButton);
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
        private Button ClockInButton;
    }
}