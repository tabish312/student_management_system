namespace Student_Management_System
{
    partial class StaffSubmission
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffSubmission));
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.labelcopyright = new System.Windows.Forms.Label();
            this.panelstudents = new System.Windows.Forms.Panel();
            this.labeltotalmonth = new System.Windows.Forms.Label();
            this.labelmonth = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.paneltime = new System.Windows.Forms.Panel();
            this.labeltoday = new System.Windows.Forms.Label();
            this.labeltotaltoday = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.labelschool = new System.Windows.Forms.Label();
            this.sfDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btngentoday = new Syncfusion.WinForms.Controls.SfButton();
            this.btngenmonth = new Syncfusion.WinForms.Controls.SfButton();
            this.labelresult = new System.Windows.Forms.Label();
            this.bunifuGradientPanel1.SuspendLayout();
            this.panelstudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.paneltime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.labelcopyright);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.White;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 472);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(653, 24);
            this.bunifuGradientPanel1.TabIndex = 11;
            // 
            // labelcopyright
            // 
            this.labelcopyright.BackColor = System.Drawing.Color.Transparent;
            this.labelcopyright.ForeColor = System.Drawing.Color.White;
            this.labelcopyright.Location = new System.Drawing.Point(32, 4);
            this.labelcopyright.Name = "labelcopyright";
            this.labelcopyright.Size = new System.Drawing.Size(589, 17);
            this.labelcopyright.TabIndex = 0;
            this.labelcopyright.Text = "Loading...";
            this.labelcopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelstudents
            // 
            this.panelstudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.panelstudents.Controls.Add(this.labeltotalmonth);
            this.panelstudents.Controls.Add(this.labelmonth);
            this.panelstudents.Controls.Add(this.pictureBox3);
            this.panelstudents.Location = new System.Drawing.Point(350, 70);
            this.panelstudents.Name = "panelstudents";
            this.panelstudents.Size = new System.Drawing.Size(188, 125);
            this.panelstudents.TabIndex = 22;
            // 
            // labeltotalmonth
            // 
            this.labeltotalmonth.ForeColor = System.Drawing.Color.White;
            this.labeltotalmonth.Location = new System.Drawing.Point(0, 62);
            this.labeltotalmonth.Name = "labeltotalmonth";
            this.labeltotalmonth.Size = new System.Drawing.Size(188, 32);
            this.labeltotalmonth.TabIndex = 1;
            this.labeltotalmonth.Text = "Rs.";
            this.labeltotalmonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelmonth
            // 
            this.labelmonth.ForeColor = System.Drawing.Color.White;
            this.labelmonth.Location = new System.Drawing.Point(0, 88);
            this.labelmonth.Name = "labelmonth";
            this.labelmonth.Size = new System.Drawing.Size(188, 32);
            this.labelmonth.TabIndex = 1;
            this.labelmonth.Text = "This Month";
            this.labelmonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Student_Management_System.Properties.Resources.Transaction_Fee;
            this.pictureBox3.Location = new System.Drawing.Point(59, 4);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(70, 70);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // paneltime
            // 
            this.paneltime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.paneltime.Controls.Add(this.labeltoday);
            this.paneltime.Controls.Add(this.labeltotaltoday);
            this.paneltime.Controls.Add(this.pictureBox2);
            this.paneltime.Location = new System.Drawing.Point(114, 70);
            this.paneltime.Name = "paneltime";
            this.paneltime.Size = new System.Drawing.Size(188, 125);
            this.paneltime.TabIndex = 23;
            // 
            // labeltoday
            // 
            this.labeltoday.ForeColor = System.Drawing.Color.White;
            this.labeltoday.Location = new System.Drawing.Point(0, 88);
            this.labeltoday.Name = "labeltoday";
            this.labeltoday.Size = new System.Drawing.Size(188, 32);
            this.labeltoday.TabIndex = 1;
            this.labeltoday.Text = "Today";
            this.labeltoday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labeltotaltoday
            // 
            this.labeltotaltoday.ForeColor = System.Drawing.Color.White;
            this.labeltotaltoday.Location = new System.Drawing.Point(0, 62);
            this.labeltotaltoday.Name = "labeltotaltoday";
            this.labeltotaltoday.Size = new System.Drawing.Size(188, 32);
            this.labeltotaltoday.TabIndex = 1;
            this.labeltotaltoday.Text = "Rs";
            this.labeltotaltoday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Student_Management_System.Properties.Resources.User_Group;
            this.pictureBox2.Location = new System.Drawing.Point(59, 4);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 70);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 20;
            this.bunifuElipse2.TargetControl = this.panelstudents;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this.paneltime;
            // 
            // labelschool
            // 
            this.labelschool.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(128)))), ((int)(((byte)(159)))));
            this.labelschool.Location = new System.Drawing.Point(0, 9);
            this.labelschool.Name = "labelschool";
            this.labelschool.Size = new System.Drawing.Size(653, 51);
            this.labelschool.TabIndex = 24;
            this.labelschool.Text = "Staff Submission Record";
            this.labelschool.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sfDataGrid
            // 
            this.sfDataGrid.AccessibleName = "Table";
            this.sfDataGrid.AllowEditing = false;
            this.sfDataGrid.AllowResizingColumns = true;
            this.sfDataGrid.AllowResizingHiddenColumns = true;
            this.sfDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            this.sfDataGrid.BackColor = System.Drawing.SystemColors.Window;
            this.sfDataGrid.Location = new System.Drawing.Point(5, 23);
            this.sfDataGrid.Name = "sfDataGrid";
            this.sfDataGrid.RowHeight = 21;
            this.sfDataGrid.Size = new System.Drawing.Size(619, 159);
            this.sfDataGrid.Style.BorderColor = System.Drawing.Color.Silver;
            this.sfDataGrid.Style.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(146)))), ((int)(((byte)(173)))));
            this.sfDataGrid.Style.HeaderStyle.TextColor = System.Drawing.Color.White;
            this.sfDataGrid.Style.HorizontalScrollBar.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(146)))), ((int)(((byte)(173)))));
            this.sfDataGrid.Style.HorizontalScrollBar.ThumbHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.sfDataGrid.Style.HorizontalScrollBar.ThumbPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.sfDataGrid.Style.HorizontalScrollBar.ThumbWidth = 12;
            this.sfDataGrid.Style.HyperlinkStyle.DefaultLinkColor = System.Drawing.Color.Red;
            this.sfDataGrid.Style.IndentCellStyle.BackColor = System.Drawing.Color.Yellow;
            this.sfDataGrid.Style.RowHeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(146)))), ((int)(((byte)(173)))));
            this.sfDataGrid.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sfDataGrid);
            this.groupBox1.Location = new System.Drawing.Point(12, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 188);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "This Month";
            // 
            // btngentoday
            // 
            this.btngentoday.AccessibleName = "Button";
            this.btngentoday.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btngentoday.Location = new System.Drawing.Point(139, 415);
            this.btngentoday.Name = "btngentoday";
            this.btngentoday.Size = new System.Drawing.Size(177, 25);
            this.btngentoday.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btngentoday.Style.PressedBackColor = System.Drawing.Color.Gray;
            this.btngentoday.TabIndex = 26;
            this.btngentoday.Text = "Generate Today\'s Report";
            this.btngentoday.Click += new System.EventHandler(this.btngentoday_Click);
            // 
            // btngenmonth
            // 
            this.btngenmonth.AccessibleName = "Button";
            this.btngenmonth.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btngenmonth.Location = new System.Drawing.Point(337, 415);
            this.btngenmonth.Name = "btngenmonth";
            this.btngenmonth.Size = new System.Drawing.Size(177, 25);
            this.btngenmonth.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btngenmonth.Style.PressedBackColor = System.Drawing.Color.Gray;
            this.btngenmonth.TabIndex = 27;
            this.btngenmonth.Text = "Generate Monthly Report";
            this.btngenmonth.Click += new System.EventHandler(this.btngenmonth_Click);
            // 
            // labelresult
            // 
            this.labelresult.Location = new System.Drawing.Point(-3, 448);
            this.labelresult.Name = "labelresult";
            this.labelresult.Size = new System.Drawing.Size(656, 23);
            this.labelresult.TabIndex = 28;
            this.labelresult.Text = "Result";
            this.labelresult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelresult.Visible = false;
            // 
            // StaffSubmission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.BorderThickness = 2;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.CaptionButtonColor = System.Drawing.Color.WhiteSmoke;
            this.CaptionButtonHoverColor = System.Drawing.Color.White;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(653, 496);
            this.Controls.Add(this.labelresult);
            this.Controls.Add(this.btngentoday);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btngenmonth);
            this.Controls.Add(this.labelschool);
            this.Controls.Add(this.panelstudents);
            this.Controls.Add(this.paneltime);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.MinimizeBox = false;
            this.Name = "StaffSubmission";
            this.ShowIcon = false;
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff Submission Record";
            this.Load += new System.EventHandler(this.StaffSubmission_Load);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.panelstudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.paneltime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label labelcopyright;
        private System.Windows.Forms.Panel panelstudents;
        private System.Windows.Forms.Label labeltotalmonth;
        private System.Windows.Forms.Label labelmonth;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel paneltime;
        private System.Windows.Forms.Label labeltoday;
        private System.Windows.Forms.Label labeltotaltoday;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label labelschool;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private Syncfusion.WinForms.Controls.SfButton btngentoday;
        private Syncfusion.WinForms.Controls.SfButton btngenmonth;
        private System.Windows.Forms.Label labelresult;
    }
}