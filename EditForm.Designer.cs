namespace Student_Management_System
{
    partial class EditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Admitdatepicker = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.comboboxclass = new Syncfusion.WinForms.ListView.SfComboBox();
            this.comboboxsection = new Syncfusion.WinForms.ListView.SfComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtregno = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnupload = new Syncfusion.WinForms.Controls.SfButton();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.txtaddress = new System.Windows.Forms.RichTextBox();
            this.DateofBirthPicker = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.ComboBoxGender = new Syncfusion.WinForms.ListView.SfComboBox();
            this.txtplaceofbirth = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtcontact = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtathername = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcnic = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtreligion = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtmothername = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtstdname = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.labelstdname = new System.Windows.Forms.Label();
            this.btncancel = new Syncfusion.WinForms.Controls.SfButton();
            this.btnsave = new Syncfusion.WinForms.Controls.SfButton();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.labelcopyright = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboboxclass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboboxsection)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxGender)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Admitdatepicker);
            this.groupBox2.Controls.Add(this.comboboxclass);
            this.groupBox2.Controls.Add(this.comboboxsection);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtregno);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(12, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "School Details";
            // 
            // Admitdatepicker
            // 
            this.Admitdatepicker.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Admitdatepicker.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            this.Admitdatepicker.ForeColor = System.Drawing.Color.DimGray;
            this.Admitdatepicker.Format = "dd/MM/yyyy";
            this.Admitdatepicker.Location = new System.Drawing.Point(515, 26);
            this.Admitdatepicker.Name = "Admitdatepicker";
            this.Admitdatepicker.Size = new System.Drawing.Size(204, 21);
            this.Admitdatepicker.Style.BorderColor = System.Drawing.Color.Silver;
            this.Admitdatepicker.Style.ForeColor = System.Drawing.Color.DimGray;
            this.Admitdatepicker.Style.HoverBorderColor = System.Drawing.Color.DarkGray;
            this.Admitdatepicker.TabIndex = 13;
            this.Admitdatepicker.Text = "DatePicker";
            this.Admitdatepicker.ThemeName = null;
            this.Admitdatepicker.Value = new System.DateTime(2000, 12, 12, 0, 0, 0, 0);
            // 
            // comboboxclass
            // 
            this.comboboxclass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboboxclass.Location = new System.Drawing.Point(193, 59);
            this.comboboxclass.Name = "comboboxclass";
            this.comboboxclass.Size = new System.Drawing.Size(155, 21);
            this.comboboxclass.Style.EditorStyle.BorderColor = System.Drawing.Color.Silver;
            this.comboboxclass.Style.EditorStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.comboboxclass.Style.EditorStyle.ForeColor = System.Drawing.Color.DimGray;
            this.comboboxclass.Style.EditorStyle.HoverBorderColor = System.Drawing.Color.DarkGray;
            this.comboboxclass.TabIndex = 14;
            // 
            // comboboxsection
            // 
            this.comboboxsection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboboxsection.Location = new System.Drawing.Point(480, 59);
            this.comboboxsection.Name = "comboboxsection";
            this.comboboxsection.Size = new System.Drawing.Size(155, 21);
            this.comboboxsection.Style.EditorStyle.BorderColor = System.Drawing.Color.Silver;
            this.comboboxsection.Style.EditorStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.comboboxsection.Style.EditorStyle.ForeColor = System.Drawing.Color.DimGray;
            this.comboboxsection.Style.EditorStyle.HoverBorderColor = System.Drawing.Color.DarkGray;
            this.comboboxsection.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(58, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Registration No:";
            // 
            // txtregno
            // 
            this.txtregno.BorderColorFocused = System.Drawing.Color.DarkGray;
            this.txtregno.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtregno.BorderColorMouseHover = System.Drawing.Color.DarkGray;
            this.txtregno.BorderThickness = 1;
            this.txtregno.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtregno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtregno.ForeColor = System.Drawing.Color.DimGray;
            this.txtregno.isPassword = false;
            this.txtregno.Location = new System.Drawing.Point(149, 26);
            this.txtregno.Margin = new System.Windows.Forms.Padding(4);
            this.txtregno.Name = "txtregno";
            this.txtregno.Size = new System.Drawing.Size(215, 21);
            this.txtregno.TabIndex = 12;
            this.txtregno.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(432, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Admitted Date:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(142, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Class:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(418, 63);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Section:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnupload);
            this.groupBox1.Controls.Add(this.pictureBoxProfile);
            this.groupBox1.Controls.Add(this.txtaddress);
            this.groupBox1.Controls.Add(this.DateofBirthPicker);
            this.groupBox1.Controls.Add(this.ComboBoxGender);
            this.groupBox1.Controls.Add(this.txtplaceofbirth);
            this.groupBox1.Controls.Add(this.txtcontact);
            this.groupBox1.Controls.Add(this.txtathername);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtcnic);
            this.groupBox1.Controls.Add(this.txtreligion);
            this.groupBox1.Controls.Add(this.txtmothername);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtstdname);
            this.groupBox1.Controls.Add(this.labelstdname);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 282);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Details";
            // 
            // btnupload
            // 
            this.btnupload.AccessibleName = "Button";
            this.btnupload.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnupload.Location = new System.Drawing.Point(614, 240);
            this.btnupload.Name = "btnupload";
            this.btnupload.Size = new System.Drawing.Size(100, 21);
            this.btnupload.TabIndex = 11;
            this.btnupload.Text = "Change";
            this.btnupload.Click += new System.EventHandler(this.btnupload_Click);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Image = global::Student_Management_System.Properties.Resources.profile_male;
            this.pictureBoxProfile.Location = new System.Drawing.Point(614, 123);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 4;
            this.pictureBoxProfile.TabStop = false;
            // 
            // txtaddress
            // 
            this.txtaddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtaddress.ForeColor = System.Drawing.Color.DimGray;
            this.txtaddress.Location = new System.Drawing.Point(87, 118);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(403, 60);
            this.txtaddress.TabIndex = 6;
            this.txtaddress.Text = "";
            // 
            // DateofBirthPicker
            // 
            this.DateofBirthPicker.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DateofBirthPicker.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            this.DateofBirthPicker.ForeColor = System.Drawing.Color.DimGray;
            this.DateofBirthPicker.Format = "dd/MM/yyyy";
            this.DateofBirthPicker.Location = new System.Drawing.Point(208, 73);
            this.DateofBirthPicker.Name = "DateofBirthPicker";
            this.DateofBirthPicker.Size = new System.Drawing.Size(155, 21);
            this.DateofBirthPicker.Style.BorderColor = System.Drawing.Color.Silver;
            this.DateofBirthPicker.Style.ForeColor = System.Drawing.Color.DimGray;
            this.DateofBirthPicker.Style.HoverBorderColor = System.Drawing.Color.DarkGray;
            this.DateofBirthPicker.TabIndex = 4;
            this.DateofBirthPicker.Text = "DatePicker";
            this.DateofBirthPicker.ThemeName = null;
            this.DateofBirthPicker.Value = new System.DateTime(2000, 12, 12, 0, 0, 0, 0);
            // 
            // ComboBoxGender
            // 
            this.ComboBoxGender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ComboBoxGender.Location = new System.Drawing.Point(335, 207);
            this.ComboBoxGender.Name = "ComboBoxGender";
            this.ComboBoxGender.Size = new System.Drawing.Size(155, 21);
            this.ComboBoxGender.Style.EditorStyle.BorderColor = System.Drawing.Color.Silver;
            this.ComboBoxGender.Style.EditorStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ComboBoxGender.Style.EditorStyle.ForeColor = System.Drawing.Color.DimGray;
            this.ComboBoxGender.Style.EditorStyle.HoverBorderColor = System.Drawing.Color.DarkGray;
            this.ComboBoxGender.TabIndex = 8;
            // 
            // txtplaceofbirth
            // 
            this.txtplaceofbirth.BorderColorFocused = System.Drawing.Color.DarkGray;
            this.txtplaceofbirth.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtplaceofbirth.BorderColorMouseHover = System.Drawing.Color.DarkGray;
            this.txtplaceofbirth.BorderThickness = 1;
            this.txtplaceofbirth.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtplaceofbirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtplaceofbirth.ForeColor = System.Drawing.Color.DimGray;
            this.txtplaceofbirth.isPassword = false;
            this.txtplaceofbirth.Location = new System.Drawing.Point(493, 73);
            this.txtplaceofbirth.Margin = new System.Windows.Forms.Padding(4);
            this.txtplaceofbirth.Name = "txtplaceofbirth";
            this.txtplaceofbirth.Size = new System.Drawing.Size(147, 21);
            this.txtplaceofbirth.TabIndex = 5;
            this.txtplaceofbirth.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtcontact
            // 
            this.txtcontact.BorderColorFocused = System.Drawing.Color.DarkGray;
            this.txtcontact.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtcontact.BorderColorMouseHover = System.Drawing.Color.DarkGray;
            this.txtcontact.BorderThickness = 1;
            this.txtcontact.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcontact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtcontact.ForeColor = System.Drawing.Color.DimGray;
            this.txtcontact.isPassword = false;
            this.txtcontact.Location = new System.Drawing.Point(317, 245);
            this.txtcontact.Margin = new System.Windows.Forms.Padding(4);
            this.txtcontact.Name = "txtcontact";
            this.txtcontact.Size = new System.Drawing.Size(173, 21);
            this.txtcontact.TabIndex = 10;
            this.txtcontact.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtathername
            // 
            this.txtathername.BorderColorFocused = System.Drawing.Color.DarkGray;
            this.txtathername.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtathername.BorderColorMouseHover = System.Drawing.Color.DarkGray;
            this.txtathername.BorderThickness = 1;
            this.txtathername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtathername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtathername.ForeColor = System.Drawing.Color.DimGray;
            this.txtathername.isPassword = false;
            this.txtathername.Location = new System.Drawing.Point(351, 31);
            this.txtathername.Margin = new System.Windows.Forms.Padding(4);
            this.txtathername.Name = "txtathername";
            this.txtathername.Size = new System.Drawing.Size(155, 21);
            this.txtathername.TabIndex = 2;
            this.txtathername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(415, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Place of Birth:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(290, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Gender:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(269, 249);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Contact:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Date Of Birth:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Father\'s Name:";
            // 
            // txtcnic
            // 
            this.txtcnic.BorderColorFocused = System.Drawing.Color.DarkGray;
            this.txtcnic.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtcnic.BorderColorMouseHover = System.Drawing.Color.DarkGray;
            this.txtcnic.BorderThickness = 1;
            this.txtcnic.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcnic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtcnic.ForeColor = System.Drawing.Color.DimGray;
            this.txtcnic.isPassword = false;
            this.txtcnic.Location = new System.Drawing.Point(106, 207);
            this.txtcnic.Margin = new System.Windows.Forms.Padding(4);
            this.txtcnic.Name = "txtcnic";
            this.txtcnic.Size = new System.Drawing.Size(155, 21);
            this.txtcnic.TabIndex = 7;
            this.txtcnic.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtreligion
            // 
            this.txtreligion.BorderColorFocused = System.Drawing.Color.DarkGray;
            this.txtreligion.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtreligion.BorderColorMouseHover = System.Drawing.Color.DarkGray;
            this.txtreligion.BorderThickness = 1;
            this.txtreligion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtreligion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtreligion.ForeColor = System.Drawing.Color.DimGray;
            this.txtreligion.isPassword = false;
            this.txtreligion.Location = new System.Drawing.Point(79, 245);
            this.txtreligion.Margin = new System.Windows.Forms.Padding(4);
            this.txtreligion.Name = "txtreligion";
            this.txtreligion.Size = new System.Drawing.Size(155, 21);
            this.txtreligion.TabIndex = 9;
            this.txtreligion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtmothername
            // 
            this.txtmothername.BorderColorFocused = System.Drawing.Color.DarkGray;
            this.txtmothername.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtmothername.BorderColorMouseHover = System.Drawing.Color.DarkGray;
            this.txtmothername.BorderThickness = 1;
            this.txtmothername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtmothername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtmothername.ForeColor = System.Drawing.Color.DimGray;
            this.txtmothername.isPassword = false;
            this.txtmothername.Location = new System.Drawing.Point(605, 31);
            this.txtmothername.Margin = new System.Windows.Forms.Padding(4);
            this.txtmothername.Name = "txtmothername";
            this.txtmothername.Size = new System.Drawing.Size(155, 21);
            this.txtmothername.TabIndex = 3;
            this.txtmothername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Address:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "B.Form/CNIC: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 249);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Religion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(529, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mother Name:";
            // 
            // txtstdname
            // 
            this.txtstdname.BorderColorFocused = System.Drawing.Color.DarkGray;
            this.txtstdname.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtstdname.BorderColorMouseHover = System.Drawing.Color.DarkGray;
            this.txtstdname.BorderThickness = 1;
            this.txtstdname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtstdname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtstdname.ForeColor = System.Drawing.Color.DimGray;
            this.txtstdname.isPassword = false;
            this.txtstdname.Location = new System.Drawing.Point(100, 31);
            this.txtstdname.Margin = new System.Windows.Forms.Padding(4);
            this.txtstdname.Name = "txtstdname";
            this.txtstdname.Size = new System.Drawing.Size(155, 21);
            this.txtstdname.TabIndex = 0;
            this.txtstdname.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // labelstdname
            // 
            this.labelstdname.AutoSize = true;
            this.labelstdname.Location = new System.Drawing.Point(17, 35);
            this.labelstdname.Name = "labelstdname";
            this.labelstdname.Size = new System.Drawing.Size(85, 13);
            this.labelstdname.TabIndex = 0;
            this.labelstdname.Text = "Student\'s Name:";
            // 
            // btncancel
            // 
            this.btncancel.AccessibleName = "Button";
            this.btncancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btncancel.Location = new System.Drawing.Point(415, 416);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(128, 25);
            this.btncancel.Style.FocusedBackColor = System.Drawing.Color.Gray;
            this.btncancel.Style.PressedBackColor = System.Drawing.Color.Gray;
            this.btncancel.TabIndex = 19;
            this.btncancel.Text = "Cancel";
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsave
            // 
            this.btnsave.AccessibleName = "Button";
            this.btnsave.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnsave.Location = new System.Drawing.Point(257, 416);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(128, 25);
            this.btnsave.Style.FocusedBackColor = System.Drawing.Color.Gray;
            this.btnsave.Style.PressedBackColor = System.Drawing.Color.Gray;
            this.btnsave.TabIndex = 18;
            this.btnsave.Text = "Save";
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
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
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 451);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(800, 24);
            this.bunifuGradientPanel1.TabIndex = 20;
            // 
            // labelcopyright
            // 
            this.labelcopyright.BackColor = System.Drawing.Color.Transparent;
            this.labelcopyright.ForeColor = System.Drawing.Color.White;
            this.labelcopyright.Location = new System.Drawing.Point(106, 4);
            this.labelcopyright.Name = "labelcopyright";
            this.labelcopyright.Size = new System.Drawing.Size(589, 17);
            this.labelcopyright.TabIndex = 0;
            this.labelcopyright.Text = "Loading...";
            this.labelcopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.BorderThickness = 2;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.CaptionButtonColor = System.Drawing.Color.WhiteSmoke;
            this.CaptionButtonHoverColor = System.Drawing.Color.White;
            this.CaptionForeColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 475);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(140)))), ((int)(((byte)(166)))));
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditForm_FormClosed);
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboboxclass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboboxsection)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxGender)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private Syncfusion.WinForms.Input.SfDateTimeEdit Admitdatepicker;
        private Syncfusion.WinForms.ListView.SfComboBox comboboxclass;
        private Syncfusion.WinForms.ListView.SfComboBox comboboxsection;
        private System.Windows.Forms.Label label13;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtregno;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox1;
        private Syncfusion.WinForms.Controls.SfButton btnupload;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.RichTextBox txtaddress;
        private Syncfusion.WinForms.Input.SfDateTimeEdit DateofBirthPicker;
        private Syncfusion.WinForms.ListView.SfComboBox ComboBoxGender;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtplaceofbirth;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtcontact;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtathername;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtcnic;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtreligion;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtmothername;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtstdname;
        private System.Windows.Forms.Label labelstdname;
        private Syncfusion.WinForms.Controls.SfButton btncancel;
        private Syncfusion.WinForms.Controls.SfButton btnsave;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label labelcopyright;
    }
}