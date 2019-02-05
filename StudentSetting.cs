using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.Controls;

namespace Student_Management_System
{
    public partial class StudentSetting : MetroForm
    {
        DbEntities db = new DbEntities();
        public StudentSetting()
        {
            InitializeComponent();
        }

        private void StudentSetting_Load(object sender, EventArgs e)
        {
            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();
            this.CaptionFont = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelresult.Font = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelcopyright.Text = "© Copyright - Student Management Sytem | Powered by TabiSoft Solutions";
            labelcopyright.Font = new Font(EmbedFont.private_fonts.Families[0], 8);

            LoadClassess();
            LoadSections();
            TabIndexing();
        }

        public void LoadClassess()
        {
            var clas = db.Randoms.Where(c => c.ID == 26).FirstOrDefault();
            var clasarr = clas.Text.Split(',');

            ArrayList ClassArray = new ArrayList();
            ClassArray.AddRange(clasarr);

            for (int i = 1; i <= ClassArray.ToArray().Length; i++)
            {
                string className = "txtclass" + i.ToString();
                BunifuMetroTextbox lbl_text = this.Controls.Find(className, true).FirstOrDefault() as BunifuMetroTextbox;
                lbl_text.Enabled = false;
            }

            for (int j = 0; j <= ClassArray.ToArray().Length - 1; j++)
            {
                string className = "txtclass" + (j + 1).ToString();
                BunifuMetroTextbox lbl_text = this.Controls.Find(className, true).FirstOrDefault() as BunifuMetroTextbox;

                lbl_text.Text = ClassArray[j].ToString();
            }
        }

        public void LoadSections()
        {
            var sec = db.Randoms.Where(c => c.ID == 27).FirstOrDefault();
            var secarr = sec.Text.Split(',');

            ArrayList Sectionarray = new ArrayList();
            Sectionarray.AddRange(secarr);

            for (int j = 0; j <= Sectionarray.ToArray().Length - 1; j++)
            {
                string className = "txtsec" + (j + 1).ToString();
                BunifuMetroTextbox lbl_text = this.Controls.Find(className, true).FirstOrDefault() as BunifuMetroTextbox;

                lbl_text.Text = Sectionarray[j].ToString();
            }
        }

        private void btnsaveclass_Click(object sender, EventArgs e)
        {
            ArrayList classList = new ArrayList();
            ArrayList feearrayList = new ArrayList();

            var clas = db.Randoms.Where(c => c.ID == 26).FirstOrDefault();
            var fee = db.Randoms.Where(c => c.ID == 32).FirstOrDefault();

            feearrayList.AddRange(fee.Text.Split(';'));

            for (int i = 0; i <= 15; i++)
            {
                string className = "txtclass" + (i + 1).ToString();
                BunifuMetroTextbox lbl_text = this.Controls.Find(className, true).FirstOrDefault() as BunifuMetroTextbox;

                if (lbl_text.Text != "")
                {
                    classList.Add(lbl_text.Text);
                }
            }

            string classess = String.Join(",", classList.ToArray());
            int classlength = classList.ToArray().Length;

            int feelength = feearrayList.ToArray().Length;


            int min = classlength - feelength;

            for (int i = 1; i <= min; i++)
            {
                feearrayList.Add("0,0");
            }

            string finalfee = String.Join(";", feearrayList.ToArray());

            try
            {
                clas.Text = classess;
                fee.Text = finalfee;
                db.Entry(clas).State = System.Data.Entity.EntityState.Modified;
                db.Entry(fee).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                labelresult.Text = ex.Message.ToString();
                labelresult.Visible = true;
                labelresult.ForeColor = Color.Red;
            }
            finally
            {
                labelresult.Text = "Saved Successfully!";
                labelresult.Visible = true;
                labelresult.ForeColor = Color.Green;
            }

        }

        private void btnsavesection_Click(object sender, EventArgs e)
        {
            ArrayList seclist = new ArrayList();
            for (int i = 0; i <= 15; i++)
            {
                string secname = "txtsec" + (i + 1).ToString();
                BunifuMetroTextbox lbl_text = this.Controls.Find(secname, true).FirstOrDefault() as BunifuMetroTextbox;

                if (lbl_text.Text != "")
                {
                    seclist.Add(lbl_text.Text);
                }
            }

            string classess = String.Join(",", seclist.ToArray());

            try
            {
                var sec = db.Randoms.Where(c => c.ID == 27).FirstOrDefault();
                sec.Text = classess.ToString();

                db.Entry(sec).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                labelresult.Text = ex.Message.ToString();
                labelresult.Visible = true;
                labelresult.ForeColor = Color.Red;
            }
            finally
            {
                labelresult.Text = "*Succesfully Saved!";
                labelresult.Visible = true;
                labelresult.ForeColor = Color.Green;
            }
        }

        public void TabIndexing()
        {
            for (int i = 1; i <= 16; i++)
            {
                string secname = "txtclass" + (i).ToString();
                BunifuMetroTextbox lbl_text = this.Controls.Find(secname, true).FirstOrDefault() as BunifuMetroTextbox;
                lbl_text.TabIndex = i;
            }

            SfButton btn = this.Controls.Find("btnsaveclass", true).FirstOrDefault() as SfButton;
            btn.TabIndex = 17;

            for (int i = 1; i <= 16; i++)
            {
                string secname = "txtsec" + (i).ToString();
                BunifuMetroTextbox lbl_text = this.Controls.Find(secname, true).FirstOrDefault() as BunifuMetroTextbox;
                lbl_text.TabIndex = (i + 1) + 16;
            }
            SfButton btn1 = this.Controls.Find("btnsavesection", true).FirstOrDefault() as SfButton;
            btn1.TabIndex = 34;
        }

        private void StudentSetting_Activated(object sender, EventArgs e)
        {
            txtclass1.Focus();
        }
    }
}