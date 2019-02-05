namespace Student_Management_System
{
    partial class SearchStudent
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
            this.groupBoxstd = new System.Windows.Forms.GroupBox();
            this.btnsearch = new Syncfusion.WinForms.Controls.SfButton();
            this.btnreset = new Syncfusion.WinForms.Controls.SfButton();
            this.comboboxclass = new Syncfusion.WinForms.ListView.SfComboBox();
            this.txtname = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtreg = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtyear = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtid = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.labelsearchname = new System.Windows.Forms.Label();
            this.labelsearchreg = new System.Windows.Forms.Label();
            this.labelyear = new System.Windows.Forms.Label();
            this.labelfilter = new System.Windows.Forms.Label();
            this.labelsearchid = new System.Windows.Forms.Label();
            this.sfDataPager = new Syncfusion.WinForms.DataPager.SfDataPager();
            this.sfDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.toolstripitem1 = new Syncfusion.Windows.Forms.Tools.toolstripitem();
            this.toolstripitem2 = new Syncfusion.Windows.Forms.Tools.toolstripitem();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.groupBoxstd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboboxclass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxstd
            // 
            this.groupBoxstd.Controls.Add(this.btnsearch);
            this.groupBoxstd.Controls.Add(this.btnreset);
            this.groupBoxstd.Controls.Add(this.comboboxclass);
            this.groupBoxstd.Controls.Add(this.txtname);
            this.groupBoxstd.Controls.Add(this.txtreg);
            this.groupBoxstd.Controls.Add(this.txtyear);
            this.groupBoxstd.Controls.Add(this.txtid);
            this.groupBoxstd.Controls.Add(this.labelsearchname);
            this.groupBoxstd.Controls.Add(this.labelsearchreg);
            this.groupBoxstd.Controls.Add(this.labelyear);
            this.groupBoxstd.Controls.Add(this.labelfilter);
            this.groupBoxstd.Controls.Add(this.labelsearchid);
            this.groupBoxstd.Controls.Add(this.sfDataPager);
            this.groupBoxstd.Controls.Add(this.sfDataGrid);
            this.groupBoxstd.Location = new System.Drawing.Point(12, 12);
            this.groupBoxstd.Name = "groupBoxstd";
            this.groupBoxstd.Size = new System.Drawing.Size(880, 599);
            this.groupBoxstd.TabIndex = 0;
            this.groupBoxstd.TabStop = false;
            this.groupBoxstd.Text = "All Students";
            // 
            // btnsearch
            // 
            this.btnsearch.AccessibleName = "Button";
            this.btnsearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnsearch.Location = new System.Drawing.Point(598, 69);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(114, 25);
            this.btnsearch.Style.FocusedBackColor = System.Drawing.Color.Gray;
            this.btnsearch.Style.PressedBackColor = System.Drawing.Color.Gray;
            this.btnsearch.TabIndex = 17;
            this.btnsearch.Text = "Search";
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // btnreset
            // 
            this.btnreset.AccessibleName = "Button";
            this.btnreset.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnreset.Location = new System.Drawing.Point(738, 69);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(118, 25);
            this.btnreset.Style.FocusedBackColor = System.Drawing.Color.Gray;
            this.btnreset.Style.PressedBackColor = System.Drawing.Color.Gray;
            this.btnreset.TabIndex = 17;
            this.btnreset.Text = "Reset";
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // comboboxclass
            // 
            this.comboboxclass.AllowNull = true;
            this.comboboxclass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboboxclass.Location = new System.Drawing.Point(106, 73);
            this.comboboxclass.Name = "comboboxclass";
            this.comboboxclass.Size = new System.Drawing.Size(155, 21);
            this.comboboxclass.Style.EditorStyle.BorderColor = System.Drawing.Color.Silver;
            this.comboboxclass.Style.EditorStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.comboboxclass.Style.EditorStyle.ForeColor = System.Drawing.Color.DimGray;
            this.comboboxclass.Style.EditorStyle.HoverBorderColor = System.Drawing.Color.DarkGray;
            this.comboboxclass.Style.EditorStyle.WatermarkForeColor = System.Drawing.Color.DarkGray;
            this.comboboxclass.TabIndex = 16;
            this.comboboxclass.Text = "Select class";
            this.comboboxclass.Watermark = "Select class";
            // 
            // txtname
            // 
            this.txtname.BorderColorFocused = System.Drawing.Color.DarkGray;
            this.txtname.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtname.BorderColorMouseHover = System.Drawing.Color.DarkGray;
            this.txtname.BorderThickness = 1;
            this.txtname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtname.ForeColor = System.Drawing.Color.DimGray;
            this.txtname.isPassword = false;
            this.txtname.Location = new System.Drawing.Point(701, 32);
            this.txtname.Margin = new System.Windows.Forms.Padding(4);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(155, 21);
            this.txtname.TabIndex = 5;
            this.txtname.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtreg
            // 
            this.txtreg.BorderColorFocused = System.Drawing.Color.DarkGray;
            this.txtreg.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtreg.BorderColorMouseHover = System.Drawing.Color.DarkGray;
            this.txtreg.BorderThickness = 1;
            this.txtreg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtreg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtreg.ForeColor = System.Drawing.Color.DimGray;
            this.txtreg.isPassword = false;
            this.txtreg.Location = new System.Drawing.Point(424, 32);
            this.txtreg.Margin = new System.Windows.Forms.Padding(4);
            this.txtreg.Name = "txtreg";
            this.txtreg.Size = new System.Drawing.Size(155, 21);
            this.txtreg.TabIndex = 5;
            this.txtreg.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtyear
            // 
            this.txtyear.BorderColorFocused = System.Drawing.Color.DarkGray;
            this.txtyear.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtyear.BorderColorMouseHover = System.Drawing.Color.DarkGray;
            this.txtyear.BorderThickness = 1;
            this.txtyear.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtyear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtyear.ForeColor = System.Drawing.Color.DimGray;
            this.txtyear.isPassword = false;
            this.txtyear.Location = new System.Drawing.Point(424, 73);
            this.txtyear.Margin = new System.Windows.Forms.Padding(4);
            this.txtyear.Name = "txtyear";
            this.txtyear.Size = new System.Drawing.Size(155, 21);
            this.txtyear.TabIndex = 5;
            this.txtyear.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtid
            // 
            this.txtid.BorderColorFocused = System.Drawing.Color.DarkGray;
            this.txtid.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtid.BorderColorMouseHover = System.Drawing.Color.DarkGray;
            this.txtid.BorderThickness = 1;
            this.txtid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtid.ForeColor = System.Drawing.Color.DimGray;
            this.txtid.isPassword = false;
            this.txtid.Location = new System.Drawing.Point(104, 32);
            this.txtid.Margin = new System.Windows.Forms.Padding(4);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(155, 21);
            this.txtid.TabIndex = 5;
            this.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // labelsearchname
            // 
            this.labelsearchname.AutoSize = true;
            this.labelsearchname.Location = new System.Drawing.Point(595, 36);
            this.labelsearchname.Name = "labelsearchname";
            this.labelsearchname.Size = new System.Drawing.Size(89, 13);
            this.labelsearchname.TabIndex = 2;
            this.labelsearchname.Text = "Search by Name:";
            // 
            // labelsearchreg
            // 
            this.labelsearchreg.AutoSize = true;
            this.labelsearchreg.Location = new System.Drawing.Point(270, 36);
            this.labelsearchreg.Name = "labelsearchreg";
            this.labelsearchreg.Size = new System.Drawing.Size(134, 13);
            this.labelsearchreg.TabIndex = 2;
            this.labelsearchreg.Text = "Search by Registration No:";
            // 
            // labelyear
            // 
            this.labelyear.AutoSize = true;
            this.labelyear.Location = new System.Drawing.Point(334, 75);
            this.labelyear.Name = "labelyear";
            this.labelyear.Size = new System.Drawing.Size(71, 13);
            this.labelyear.TabIndex = 2;
            this.labelyear.Text = "Filter by Year:";
            // 
            // labelfilter
            // 
            this.labelfilter.AutoSize = true;
            this.labelfilter.Location = new System.Drawing.Point(16, 75);
            this.labelfilter.Name = "labelfilter";
            this.labelfilter.Size = new System.Drawing.Size(73, 13);
            this.labelfilter.TabIndex = 2;
            this.labelfilter.Text = "Filter by class:";
            // 
            // labelsearchid
            // 
            this.labelsearchid.AutoSize = true;
            this.labelsearchid.Location = new System.Drawing.Point(25, 36);
            this.labelsearchid.Name = "labelsearchid";
            this.labelsearchid.Size = new System.Drawing.Size(72, 13);
            this.labelsearchid.TabIndex = 2;
            this.labelsearchid.Text = "Search by ID:";
            // 
            // sfDataPager
            // 
            this.sfDataPager.AccessibleName = "DataPager";
            this.sfDataPager.Location = new System.Drawing.Point(289, 567);
            this.sfDataPager.Name = "sfDataPager";
            this.sfDataPager.Size = new System.Drawing.Size(300, 24);
            this.sfDataPager.TabIndex = 1;
            this.sfDataPager.Text = "sfDataPager1";
            // 
            // sfDataGrid
            // 
            this.sfDataGrid.AccessibleName = "Table";
            this.sfDataGrid.AllowEditing = false;
            this.sfDataGrid.AllowResizingColumns = true;
            this.sfDataGrid.AllowResizingHiddenColumns = true;
            this.sfDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            this.sfDataGrid.BackColor = System.Drawing.SystemColors.Window;
            this.sfDataGrid.Location = new System.Drawing.Point(6, 116);
            this.sfDataGrid.Name = "sfDataGrid";
            this.sfDataGrid.RowHeight = 21;
            this.sfDataGrid.Size = new System.Drawing.Size(868, 445);
            this.sfDataGrid.Style.BorderColor = System.Drawing.Color.Silver;
            this.sfDataGrid.Style.CurrentCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.sfDataGrid.Style.CurrentCellStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.sfDataGrid.Style.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(146)))), ((int)(((byte)(173)))));
            this.sfDataGrid.Style.HeaderStyle.TextColor = System.Drawing.Color.White;
            this.sfDataGrid.Style.HorizontalScrollBar.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(146)))), ((int)(((byte)(173)))));
            this.sfDataGrid.Style.HorizontalScrollBar.ThumbHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.sfDataGrid.Style.HorizontalScrollBar.ThumbPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.sfDataGrid.Style.HorizontalScrollBar.ThumbWidth = 12;
            this.sfDataGrid.Style.HyperlinkStyle.DefaultLinkColor = System.Drawing.Color.Red;
            this.sfDataGrid.Style.IndentCellStyle.BackColor = System.Drawing.Color.Yellow;
            this.sfDataGrid.Style.RowHeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(146)))), ((int)(((byte)(173)))));
            this.sfDataGrid.TabIndex = 1;
            this.sfDataGrid.DataSourceChanged += new Syncfusion.WinForms.DataGrid.Events.DataSourceChangedEventHandler(this.sfDataGrid_DataSourceChanged);
            this.sfDataGrid.CellDoubleClick += new Syncfusion.WinForms.DataGrid.Events.CellClickEventHandler(this.sfDataGrid_CellDoubleClick);
            // 
            // toolstripitem1
            // 
            this.toolstripitem1.Name = "toolstripitem1";
            this.toolstripitem1.Size = new System.Drawing.Size(23, 23);
            this.toolstripitem1.Text = "toolstripitem1";
            // 
            // toolstripitem2
            // 
            this.toolstripitem2.Name = "toolstripitem2";
            this.toolstripitem2.Size = new System.Drawing.Size(23, 23);
            this.toolstripitem2.Text = "toolstripitem2";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            // 
            // SearchStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.BorderThickness = 2;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.CaptionButtonColor = System.Drawing.Color.WhiteSmoke;
            this.CaptionButtonHoverColor = System.Drawing.Color.White;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(888, 614);
            this.Controls.Add(this.groupBoxstd);
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.MinimizeBox = false;
            this.Name = "SearchStudent";
            this.ShowIcon = false;
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Student";
            this.Load += new System.EventHandler(this.SearchStudent_Load);
            this.groupBoxstd.ResumeLayout(false);
            this.groupBoxstd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboboxclass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxstd;
        private Syncfusion.WinForms.DataPager.SfDataPager sfDataPager;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid;
        private System.Windows.Forms.Label labelsearchid;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtid;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtreg;
        private System.Windows.Forms.Label labelsearchreg;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtname;
        private System.Windows.Forms.Label labelsearchname;
        private System.Windows.Forms.Label labelfilter;
        private Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitem1;
        private Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitem2;
        private Syncfusion.WinForms.ListView.SfComboBox comboboxclass;
        private System.Windows.Forms.Label labelyear;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtyear;
        private Syncfusion.WinForms.Controls.SfButton btnreset;
        private Syncfusion.WinForms.Controls.SfButton btnsearch;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}