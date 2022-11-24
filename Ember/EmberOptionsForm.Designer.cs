namespace Ember
{
    partial class EmberOptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.closeFormButton = new System.Windows.Forms.Button();
            this.listOfBlackListedProgramInput = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listOfBlackListedSites = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveOptionsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Ember.Properties.Resources.TopBar;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(773, 25);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EmberOptionsForm_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EmberOptionsForm_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EmberOptionsForm_MouseUp);
            // 
            // closeFormButton
            // 
            this.closeFormButton.BackgroundImage = global::Ember.Properties.Resources.xOff;
            this.closeFormButton.FlatAppearance.BorderSize = 0;
            this.closeFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeFormButton.ForeColor = System.Drawing.Color.Firebrick;
            this.closeFormButton.Location = new System.Drawing.Point(775, 1);
            this.closeFormButton.Name = "closeFormButton";
            this.closeFormButton.Size = new System.Drawing.Size(25, 25);
            this.closeFormButton.TabIndex = 6;
            this.closeFormButton.UseVisualStyleBackColor = true;
            this.closeFormButton.Click += new System.EventHandler(this.closeFormButton_Click);
            // 
            // listOfBlackListedProgramInput
            // 
            this.listOfBlackListedProgramInput.Location = new System.Drawing.Point(70, 85);
            this.listOfBlackListedProgramInput.Name = "listOfBlackListedProgramInput";
            this.listOfBlackListedProgramInput.Size = new System.Drawing.Size(703, 131);
            this.listOfBlackListedProgramInput.TabIndex = 7;
            this.listOfBlackListedProgramInput.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(70, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Program blacklist";
            // 
            // listOfBlackListedSites
            // 
            this.listOfBlackListedSites.Location = new System.Drawing.Point(70, 263);
            this.listOfBlackListedSites.Name = "listOfBlackListedSites";
            this.listOfBlackListedSites.Size = new System.Drawing.Size(703, 131);
            this.listOfBlackListedSites.TabIndex = 10;
            this.listOfBlackListedSites.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(70, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Site blacklist";
            // 
            // saveOptionsButton
            // 
            this.saveOptionsButton.Location = new System.Drawing.Point(679, 400);
            this.saveOptionsButton.Name = "saveOptionsButton";
            this.saveOptionsButton.Size = new System.Drawing.Size(94, 29);
            this.saveOptionsButton.TabIndex = 12;
            this.saveOptionsButton.Text = "SAVE";
            this.saveOptionsButton.UseVisualStyleBackColor = true;
            this.saveOptionsButton.Click += new System.EventHandler(this.saveOptionsButton_Click);
            // 
            // EmberOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveOptionsButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listOfBlackListedSites);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listOfBlackListedProgramInput);
            this.Controls.Add(this.closeFormButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmberOptionsForm";
            this.Text = "EmberOptionsForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.EmberOptionsForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EmberOptionsForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EmberOptionsForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EmberOptionsForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button closeFormButton;
        private RichTextBox listOfBlackListedProgramInput;
        private Label label1;
        private RichTextBox listOfBlackListedSites;
        private Label label2;
        private Button saveOptionsButton;
    }
}