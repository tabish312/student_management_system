using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Design;
using SharpConfig;


namespace Student_Management_System
{
    public partial class FormMain : MetroForm
    {
        DbEntities db = new DbEntities();
        System.Timers.Timer tm = new System.Timers.Timer();
        List<StudentData> li;
        List<StudentFee> fe;
        SearchStudent search;
        StudentSetting stdsetting;
        public FormMain()
        {
            InitializeComponent();

            int height = SystemInformation.VirtualScreen.Height;
            int width = SystemInformation.VirtualScreen.Width;

            this.Size = new Size(width - 8, height - 44);
            this.Top = 0;
            this.Left = 4;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tm.Interval = 1000;
            tm.Elapsed += Tm_Elapsed;
            tm.Start();

            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();
            this.CaptionFont = new Font(EmbedFont.private_fonts.Families[2], 9);
            btndashbaord.TextFont = new Font(EmbedFont.private_fonts.Families[0], 10);
            btnstudent.TextFont = new Font(EmbedFont.private_fonts.Families[0], 10);
            btnfees.TextFont = new Font(EmbedFont.private_fonts.Families[0], 10);
            btnabout.TextFont = new Font(EmbedFont.private_fonts.Families[0], 10);
            btnsetting.TextFont = new Font(EmbedFont.private_fonts.Families[0], 10);
            btnlogout.TextFont = new Font(EmbedFont.private_fonts.Families[0], 10);
            labelschool.Font = new Font(EmbedFont.private_fonts.Families[0], 18);
            labelschool.Text = Student_Management_System.Properties.Resources.school_name;
            labeltotalstd.Font = new Font(EmbedFont.private_fonts.Families[2], 12, FontStyle.Bold);
            labelstd.Font = new Font(EmbedFont.private_fonts.Families[0], 10);
            labeltotalfeede.Font = new Font(EmbedFont.private_fonts.Families[2], 12, FontStyle.Bold);
            labelfeede.Font = new Font(EmbedFont.private_fonts.Families[0], 10);
            labelfee.Font = new Font(EmbedFont.private_fonts.Families[2], 10, FontStyle.Bold);
            labelfee.Text = "RS." + TotalAmountPerMonth() + "/-";
            labelfeelbl.Font = new Font(EmbedFont.private_fonts.Families[0], 10);
            labelcalender.Font = new Font(EmbedFont.private_fonts.Families[0], 9);
            labelclock.Font = new Font(EmbedFont.private_fonts.Families[0], 9);
            labeltime.Font = new Font(EmbedFont.private_fonts.Families[0], 22);
            labelcopyright.Text = "© Copyright - Student Management Sytem | Powered by TabiSoft Solutions";
            labelcopyright.Font = new Font(EmbedFont.private_fonts.Families[0], 9);
            Calendar.Style.Header.Font = new Font(EmbedFont.private_fonts.Families[0], 11, FontStyle.Bold);
            Calendar.Style.Header.DayNamesFont = new Font(EmbedFont.private_fonts.Families[0], 8, FontStyle.Regular);
            Calendar.SelectedDate = DateTime.Now;
            labelstudents.Font = new Font(EmbedFont.private_fonts.Families[0], 18);
            labelfeemain.Font = new Font(EmbedFont.private_fonts.Families[0], 18);
            labelstdadd.Font = new Font(EmbedFont.private_fonts.Families[0], 10);
            labelstddel.Font = new Font(EmbedFont.private_fonts.Families[0], 10);
            labelstdmod.Font = new Font(EmbedFont.private_fonts.Families[0], 10);
            labelstdsetting.Font = new Font(EmbedFont.private_fonts.Families[0], 10);
            labelstdearch.Font = new Font(EmbedFont.private_fonts.Families[0], 10);
            labeladdfee.Font = new Font(EmbedFont.private_fonts.Families[0], 10);
            labelfeeDefaulters.Font = new Font(EmbedFont.private_fonts.Families[0], 10);
            labelfeevouchers.Font = new Font(EmbedFont.private_fonts.Families[0], 10);
            labelfeesetting.Font = new Font(EmbedFont.private_fonts.Families[0], 10);
            labelsubmittedfee.Font = new Font(EmbedFont.private_fonts.Families[0], 10);

            labelstudentsub.Font = new Font(EmbedFont.private_fonts.Families[0], 10);


            li = db.StudentDatas.ToList();
            labeltotalstd.Text = li.Count.ToString();
            fe = db.StudentFees.Where(c => c.Submitted == false).ToList();
            labeltotalfeede.Text = fe.Count.ToString();
            search = new SearchStudent();
            stdsetting = new StudentSetting();




        }

        private void Tm_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                labeltime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            }));
        }

        bool logout = false;
        private void btnlogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Log Out - Student Management Sytem", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                this.Hide();
                logout = true;
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                /*/ if (settings.Count == 0 | settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {/*/
                settings["LastLogin"].Value = DateTime.Now.AddMinutes(-30).ToString();

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                FormLogin lgn = new FormLogin();
                lgn.ShowDialog();
            }
        }

        private void btndashbaord_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                return;
            }
            else
            {
                tabControl.SelectedIndex = 0;
            }
        }

        private void panelmenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnstudent_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                return;
            }
            else
            {
                tabControl.SelectedIndex = 1;
            }
        }

        private void btnfees_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 2)
            {
                return;
            }
            else
            {
                tabControl.SelectedIndex = 2;
            }
        }

        private void btnabout_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 3)
            {
                return;
            }
            else
            {
                tabControl.SelectedIndex = 3;
            }
        }

        private void btnsetting_Click(object sender, EventArgs e)
        {

        }

        private void tabPagedash_Click(object sender, EventArgs e)
        {

        }

        public DataTable GetDataTable()
        {
            DataTable employeeCollection = new DataTable();
            var dt = DateTime.Now;

            employeeCollection.Columns.Add("EmployeeID", typeof(int));
            employeeCollection.Columns[0].ColumnName = "Employee ID";
            employeeCollection.Columns.Add("EmployeeName", typeof(string));
            employeeCollection.Columns["EmployeeName"].ColumnName = "Employee Name";
            employeeCollection.Columns.Add("CustomerID", typeof(string));
            employeeCollection.Columns["CustomerID"].ColumnName = "Customer ID";
            employeeCollection.Columns.Add("Country", typeof(string));
            employeeCollection.Columns.Add("Date", typeof(DateTime));
            employeeCollection.Columns.Add("Button", typeof(string));
            employeeCollection.Columns["Button"].ColumnName = "Button";


            employeeCollection.Rows.Add(1001, "Belgim", "Yhgtr", "US", new DateTime(dt.Year, dt.Month, dt.Day), "aaa");

            return employeeCollection;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DbEntityRefresh.Refresh(db);


            li = db.StudentDatas.ToList();
            labeltotalstd.Text = li.Count.ToString();

            fe = db.StudentFees.Where(c => c.Submitted == false).ToList();
            labeltotalfeede.Text = fe.Count.ToString();


            labelfee.Text = "RS." + TotalAmountPerMonth() + "/-";

            switch (tabControl.SelectedIndex)
            {
                case 0:
                    this.btndashbaord.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(128)))), ((int)(((byte)(159)))));
                    this.btnstudent.Normalcolor = Color.Transparent;
                    this.btnfees.Normalcolor = Color.Transparent;
                    this.btnsetting.Normalcolor = Color.Transparent;
                    this.btnabout.Normalcolor = Color.Transparent;
                    this.btnsetting.Normalcolor = Color.Transparent;
                    break;
                case 1:
                    this.btnstudent.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(128)))), ((int)(((byte)(159)))));
                    this.btndashbaord.Normalcolor = Color.Transparent;
                    this.btnfees.Normalcolor = Color.Transparent;
                    this.btnsetting.Normalcolor = Color.Transparent;
                    this.btnabout.Normalcolor = Color.Transparent;
                    this.btnsetting.Normalcolor = Color.Transparent;
                    break;
                case 2:
                    this.btnstudent.Normalcolor = Color.Transparent;
                    this.btndashbaord.Normalcolor = Color.Transparent;
                    this.btnfees.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(128)))), ((int)(((byte)(159)))));
                    this.btnsetting.Normalcolor = Color.Transparent;
                    this.btnabout.Normalcolor = Color.Transparent;
                    this.btnsetting.Normalcolor = Color.Transparent;
                    break;
                case 3:
                    this.btnstudent.Normalcolor = Color.Transparent;
                    this.btndashbaord.Normalcolor = Color.Transparent;
                    this.btnfees.Normalcolor = Color.Transparent;
                    this.btnsetting.Normalcolor = Color.Transparent;
                    this.btnabout.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(128)))), ((int)(((byte)(159)))));
                    this.btnsetting.Normalcolor = Color.Transparent;
                    break;
            }
        }

        private void paneladdstd_Click(object sender, EventArgs e)
        {
            AddStudent ad = new AddStudent();
            ad.Show();

        }

        private void labelstdadd_Click(object sender, EventArgs e)
        {
            paneladdstd_Click(sender, e);
        }
        private void pictureBoxaddstd_Click(object sender, EventArgs e)
        {
            paneladdstd_Click(sender, e);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void panelmodstd_Click(object sender, EventArgs e)
        {

            ModifyStudent mod = new ModifyStudent();
            mod.ShowDialog();
        }

        private Point NewChildLocation()
        {
            return new Point(this.Left + (this.Width - 232), Bottom - 52);
        }

        private void pictureBoxmodstd_Click(object sender, EventArgs e)
        {
            panelmodstd_Click(sender, e);
        }

        private void labelstdmod_Click(object sender, EventArgs e)
        {
            panelmodstd_Click(sender, e);
        }

        private void paneldelstd_Click(object sender, EventArgs e)
        {
            DeleteStudent del = new DeleteStudent();
            del.ShowDialog();
        }

        private void stdelete_Click(object sender, EventArgs e)
        {
            paneldelstd_Click(sender, e);
        }

        private void labelstddel_Click(object sender, EventArgs e)
        {
            paneldelstd_Click(sender, e);
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            DbEntityRefresh.Refresh(db);

        }

        private void panelstdsearch_Click(object sender, EventArgs e)
        {

            search.ShowDialog();
        }

        private void stdsearch_click(object sender, EventArgs e)
        {
            panelstdsearch_Click(sender, e);
        }

        private void labelstdearch_Click(object sender, EventArgs e)
        {
            panelstdsearch_Click(sender, e);
        }

        private void panelfeevouchers_Click(object sender, EventArgs e)
        {
            FeeVoucher feeVoucher = new FeeVoucher();
            feeVoucher.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            panelfeevouchers_Click(sender, e);
        }

        private void labelfeevouchers_Click(object sender, EventArgs e)
        {
            panelfeevouchers_Click(sender, e);
        }

        private void paneladdfee_Click(object sender, EventArgs e)
        {
            FeeSubmission submission = new FeeSubmission();
            submission.ShowDialog();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            paneladdfee_Click(sender, e);
        }

        private void labeladdfee_Click(object sender, EventArgs e)
        {
            paneladdfee_Click(sender, e);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!logout)
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                /*/ if (settings.Count == 0 | settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {/*/
                settings["LastLogin"].Value = DateTime.Now.AddMinutes(3).ToString();

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
        }

        public string TotalAmountPerMonth()
        {
            int index = 0;

            switch (DateTime.Now.Month)
            {
                case 1:
                    index = 0;
                    break;
                case 2:
                    index = 1;
                    break;
                case 3:
                    index = 2;
                    break;
                case 4:
                    index = 3;
                    break;
                case 5:
                    index = 4;
                    break;
                case 6:
                    index = 5;
                    break;
                case 7:
                    index = 6;
                    break;
                case 8:
                    index = 7;
                    break;
                case 9:
                    index = 8;
                    break;
                case 10:
                    index = 9;
                    break;
                case 11:
                    index = 10;
                    break;
                case 12:
                    index = 11;
                    break;
            }

            var amount = db.Randoms.Where(c => c.ID == 5).FirstOrDefault();
            var amountarray = amount.Text.Split(',');
            return amountarray[index].ToString();
        }

        private void panelfeedefaulters_Click(object sender, EventArgs e)
        {
            FeeDefaulters feeDefaulters = new FeeDefaulters();
            feeDefaulters.ShowDialog();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            panelfeedefaulters_Click(sender, e);
        }

        private void labelfeeDefaulters_Click(object sender, EventArgs e)
        {
            panelfeedefaulters_Click(sender, e);
        }

        private void panelsubmittedfee_Click(object sender, EventArgs e)
        {
            StaffSubmission stf = new StaffSubmission();
            stf.ShowDialog();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            panelsubmittedfee_Click(sender, e);
        }

        private void labelsubmittedfee_Click(object sender, EventArgs e)
        {
            panelsubmittedfee_Click(sender, e);
        }

        private void panelallstdsubmit_Click(object sender, EventArgs e)
        {
            StudentSubmission std = new StudentSubmission();
            std.ShowDialog();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            panelallstdsubmit_Click(sender, e);
        }

        private void labelstudentsub_Click(object sender, EventArgs e)
        {
            panelallstdsubmit_Click(sender, e);
        }

        private void panelfeesetting_Click(object sender, EventArgs e)
        {
            FeeSetting feeSetting = new FeeSetting();
            feeSetting.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            panelfeesetting_Click(sender, e);
        }

        private void labelfeesetting_Click(object sender, EventArgs e)
        {
            panelfeesetting_Click(sender, e);
        }

        private void panelstdsetting_Click(object sender, EventArgs e)
        {
            stdsetting.ShowDialog();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            panelstdsetting_Click(sender, e);
        }

        private void labelstdsetting_Click(object sender, EventArgs e)
        {
            panelstdsetting_Click(sender, e);
        }
    }
}
