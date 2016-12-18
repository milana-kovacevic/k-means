namespace k_means
{
    partial class PictureEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureEditor));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.ButtonEdit = new System.Windows.Forms.Button();
            this.kChooser = new System.Windows.Forms.TrackBar();
            this.textBoxChooseK = new System.Windows.Forms.TextBox();
            this.textBoxPrecision = new System.Windows.Forms.TextBox();
            this.PrecisionSlider = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kChooser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrecisionSlider)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 98);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(461, 304);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Cursor = System.Windows.Forms.Cursors.Default;
            this.ButtonEdit.FlatAppearance.BorderSize = 2;
            this.ButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.ButtonEdit.ForeColor = System.Drawing.Color.SeaGreen;
            this.ButtonEdit.Location = new System.Drawing.Point(411, 41);
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(62, 50);
            this.ButtonEdit.TabIndex = 2;
            this.ButtonEdit.Text = "GO";
            this.ButtonEdit.UseVisualStyleBackColor = true;
            this.ButtonEdit.Click += new System.EventHandler(this.editPicture);
            // 
            // kChooser
            // 
            this.kChooser.LargeChange = 3;
            this.kChooser.Location = new System.Drawing.Point(12, 46);
            this.kChooser.Maximum = 50;
            this.kChooser.Minimum = 1;
            this.kChooser.Name = "kChooser";
            this.kChooser.Size = new System.Drawing.Size(257, 45);
            this.kChooser.TabIndex = 5;
            this.kChooser.Value = 2;
            // 
            // textBoxChooseK
            // 
            this.textBoxChooseK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxChooseK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxChooseK.Location = new System.Drawing.Point(12, 27);
            this.textBoxChooseK.Name = "textBoxChooseK";
            this.textBoxChooseK.Size = new System.Drawing.Size(94, 13);
            this.textBoxChooseK.TabIndex = 6;
            this.textBoxChooseK.Text = "Number of colors:";
            // 
            // textBoxPrecision
            // 
            this.textBoxPrecision.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxPrecision.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPrecision.Location = new System.Drawing.Point(274, 27);
            this.textBoxPrecision.Name = "textBoxPrecision";
            this.textBoxPrecision.Size = new System.Drawing.Size(96, 13);
            this.textBoxPrecision.TabIndex = 8;
            this.textBoxPrecision.Text = "Precision:";
            // 
            // PrecisionSlider
            // 
            this.PrecisionSlider.LargeChange = 3;
            this.PrecisionSlider.Location = new System.Drawing.Point(274, 46);
            this.PrecisionSlider.Minimum = 1;
            this.PrecisionSlider.Name = "PrecisionSlider";
            this.PrecisionSlider.Size = new System.Drawing.Size(129, 45);
            this.PrecisionSlider.TabIndex = 7;
            this.PrecisionSlider.Value = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(485, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenImage);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.savePicture);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitAppliction);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // readHelpToolStripMenuItem
            // 
            this.readHelpToolStripMenuItem.Name = "readHelpToolStripMenuItem";
            this.readHelpToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.readHelpToolStripMenuItem.Text = "Read Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.About);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 98);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(461, 23);
            this.progressBar.TabIndex = 10;
            this.progressBar.Visible = false;
            // 
            // PictureEditor
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(485, 411);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.textBoxPrecision);
            this.Controls.Add(this.PrecisionSlider);
            this.Controls.Add(this.textBoxChooseK);
            this.Controls.Add(this.kChooser);
            this.Controls.Add(this.ButtonEdit);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(501, 120);
            this.Name = "PictureEditor";
            this.Text = "Picture Editor";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DropingFile);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.EnteringDrag);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kChooser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrecisionSlider)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button ButtonEdit;
        private System.Windows.Forms.TextBox textBoxChooseK;
        private System.Windows.Forms.TextBox textBoxPrecision;
        private System.Windows.Forms.TrackBar PrecisionSlider;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.TrackBar kChooser;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

