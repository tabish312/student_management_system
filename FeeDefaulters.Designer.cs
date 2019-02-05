namespace Student_Management_System
{
    partial class FeeDefaulters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeeDefaulters));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboboxclass = new Syncfusion.WinForms.ListView.SfComboBox();
            this.comboboxsection = new Syncfusion.WinForms.ListView.SfComboBox();
            this.btnsearch = new Syncfusion.WinForms.Controls.SfButton();
            this.label1 = new System.Windows.Forms.Label();
            this.labelstdidaa = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelstd = new System.Windows.Forms.Label();
            this.labelstdsub = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelstddef = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnreset = new Syncfusion.WinForms.Controls.SfButton();
            this.btnprint = new Syncfusion.WinForms.Controls.SfButton();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.labelcopyright = new System.Windows.Forms.Label();
            this.labelresult = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboboxclass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboboxsection)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.bunifuGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboboxclass);
            this.groupBox1.Controls.Add(this.comboboxsection);
            this.groupBox1.Controls.Add(this.btnsearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelstdidaa);
            this.groupBox1.Location = new System.Drawing.Point(34, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Class";
            // 
            // comboboxclass
            // 
            this.comboboxclass.AllowNull = true;
            this.comboboxclass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboboxclass.Location = new System.Drawing.Point(90, 40);
            this.comboboxclass.Name = "comboboxclass";
            this.comboboxclass.Size = new System.Drawing.Size(155, 21);
            this.comboboxclass.Style.EditorStyle.BorderColor = System.Drawing.Color.Silver;
            this.comboboxclass.Style.EditorStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.comboboxclass.Style.EditorStyle.ForeColor = System.Drawing.Color.DimGray;
            this.comboboxclass.Style.EditorStyle.HoverBorderColor = System.Drawing.Color.DarkGray;
            this.comboboxclass.Style.EditorStyle.WatermarkForeColor = System.Drawing.Color.DimGray;
            this.comboboxclass.Style.ReadOnlyEditorStyle.WatermarkForeColor = System.Drawing.Color.Gray;
            this.comboboxclass.TabIndex = 16;
            this.comboboxclass.Text = "Select Class";
            this.comboboxclass.Watermark = "Select Class";
            // 
            // comboboxsection
            // 
            this.comboboxsection.AllowNull = true;
            this.comboboxsection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboboxsection.Location = new System.Drawing.Point(90, 84);
            this.comboboxsection.Name = "comboboxsection";
            this.comboboxsection.Size = new System.Drawing.Size(158, 22);
            this.comboboxsection.Style.EditorStyle.BorderColor = System.Drawing.Color.Silver;
            this.comboboxsection.Style.EditorStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.comboboxsection.Style.EditorStyle.ForeColor = System.Drawing.Color.DimGray;
            this.comboboxsection.Style.EditorStyle.HoverBorderColor = System.Drawing.Color.DarkGray;
            this.comboboxsection.Style.EditorStyle.WatermarkForeColor = System.Drawing.Color.DimGray;
            this.comboboxsection.TabIndex = 17;
            this.comboboxsection.Text = "Select Section";
            this.comboboxsection.Watermark = "Select Section";
            // 
            // btnsearch
            // 
            this.btnsearch.AccessibleName = "Button";
            this.btnsearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnsearch.Location = new System.Drawing.Point(76, 130);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(128, 25);
            this.btnsearch.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnsearch.Style.PressedBackColor = System.Drawing.Color.Gray;
            this.btnsearch.TabIndex = 4;
            this.btnsearch.Text = "Search";
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Section:";
            // 
            // labelstdidaa
            // 
            this.labelstdidaa.AutoSize = true;
            this.labelstdidaa.Location = new System.Drawing.Point(46, 44);
            this.labelstdidaa.Name = "labelstdidaa";
            this.labelstdidaa.Size = new System.Drawing.Size(35, 13);
            this.labelstdidaa.TabIndex = 10;
            this.labelstdidaa.Text = "Class:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelstd);
            this.groupBox2.Controls.Add(this.labelstdsub);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelstddef);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(339, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 195);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Class Details";
            // 
            // labelstd
            // 
            this.labelstd.AutoSize = true;
            this.labelstd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelstd.Location = new System.Drawing.Point(162, 50);
            this.labelstd.Name = "labelstd";
            this.labelstd.Size = new System.Drawing.Size(25, 15);
            this.labelstd.TabIndex = 2;
            this.labelstd.Text = "Nil";
            // 
            // labelstdsub
            // 
            this.labelstdsub.AutoSize = true;
            this.labelstdsub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelstdsub.ForeColor = System.Drawing.Color.Green;
            this.labelstdsub.Location = new System.Drawing.Point(163, 90);
            this.labelstdsub.Name = "labelstdsub";
            this.labelstdsub.Size = new System.Drawing.Size(25, 15);
            this.labelstdsub.TabIndex = 2;
            this.labelstdsub.Text = "Nil";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Students:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Submitted:";
            // 
            // labelstddef
            // 
            this.labelstddef.AutoSize = true;
            this.labelstddef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelstddef.ForeColor = System.Drawing.Color.Red;
            this.labelstddef.Location = new System.Drawing.Point(162, 130);
            this.labelstddef.Name = "labelstddef";
            this.labelstddef.Size = new System.Drawing.Size(25, 15);
            this.labelstddef.TabIndex = 2;
            this.labelstddef.Text = "Nil";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total Defaulters:";
            // 
            // btnreset
            // 
            this.btnreset.AccessibleName = "Button";
            this.btnreset.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnreset.Location = new System.Drawing.Point(334, 237);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(128, 25);
            this.btnreset.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnreset.Style.PressedBackColor = System.Drawing.Color.Gray;
            this.btnreset.TabIndex = 6;
            this.btnreset.Text = "Reset";
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnprint
            // 
            this.btnprint.AccessibleName = "Button";
            this.btnprint.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnprint.Location = new System.Drawing.Point(186, 237);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(128, 25);
            this.btnprint.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnprint.Style.PressedBackColor = System.Drawing.Color.Gray;
            this.btnprint.TabIndex = 5;
            this.btnprint.Text = "Print";
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
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
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 300);
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
            // labelresult
            // 
            this.labelresult.Location = new System.Drawing.Point(-3, 274);
            this.labelresult.Name = "labelresult";
            this.labelresult.Size = new System.Drawing.Size(656, 23);
            this.labelresult.TabIndex = 21;
            this.labelresult.Text = "Result";
            this.labelresult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelresult.Visible = false;
            // 
            // FeeDefaulters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.BorderThickness = 2;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.CaptionButtonColor = System.Drawing.Color.WhiteSmoke;
            this.CaptionButtonHoverColor = System.Drawing.Color.White;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(653, 324);
            this.Controls.Add(this.labelresult);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.MinimizeBox = false;
            this.Name = "FeeDefaulters";
            this.ShowIcon = false;
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fee Defaulters";
            this.Load += new System.EventHandler(this.FeeDefaulters_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboboxclass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboboxsection)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelstdidaa;
        private System.Windows.Forms.Label label1;
        private Syncfusion.WinForms.Controls.SfButton btnsearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelstd;
        private System.Windows.Forms.Label labelstdsub;
        private System.Windows.Forms.Label labelstddef;
        private Syncfusion.WinForms.Controls.SfButton btnreset;
        private Syncfusion.WinForms.Controls.SfButton btnprint;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label labelcopyright;
        private System.Windows.Forms.Label labelresult;
        private Syncfusion.WinForms.ListView.SfComboBox comboboxclass;
        private Syncfusion.WinForms.ListView.SfComboBox comboboxsection;
    }
}