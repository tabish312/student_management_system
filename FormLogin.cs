using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management_System
{
    public partial class FormLogin : Form
    {
        private DbEntities db = new DbEntities();

        
        public FormLogin()
        {
            InitializeComponent();
            this.Icon = global::Student_Management_System.Properties.Resources.icon;
            this.ShowIcon = true;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();

            labelbtm.Font = new Font(EmbedFont.private_fonts.Families[0], 7);
            labelLogin.Font = new Font(EmbedFont.private_fonts.Families[0], 13);
            labelLogin.Focus();

        }

        private void txtpass_OnValueChanged(object sender, EventArgs e)
        {
            txtpass.isPassword = true;
        }

        private void FormLogin_Activated(object sender, EventArgs e)
        {
            labelLogin.Focus();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

            if (txtuser.Text != null && txtuser.Text != "")
            {
                if (txtpass.Text != null && txtpass.Text != "")
                {
                    this.Cursor = Cursors.AppStarting;
                    var query = from u in db.UserLogins
                                where u.UserName == txtuser.Text && u.Password == txtpass.Text
                                select u;

                    if (query.FirstOrDefault() != null)
                    {
                        if (MessageBox.Show("Login Successful at " + DateTime.Now.ToShortTimeString(), "Student Management System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                        {
                            this.Cursor = Cursors.Arrow;
                            this.Hide();

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

                            FormMain dsh = new FormMain();
                            dsh.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You have entered an invalid username or password", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Arrow;
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Please Enter Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void pictureBoxclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
