using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;

namespace Student_Management_System
{
    public partial class ModifyOthersFee : MetroForm
    {
        DbEntities db = new DbEntities();
        public ModifyOthersFee()
        {
            InitializeComponent();
            this.Icon = global::Student_Management_System.Properties.Resources.icon;
            this.ShowIcon = true;
        }

        private void ModifyOthersFee_Load_1(object sender, EventArgs e)
        {
            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();
            this.CaptionFont = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelresult.Font = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelcopyright.Text = "© Copyright - Student Management Sytem | Powered by TabiSoft Solutions";
            labelcopyright.Font = new Font(EmbedFont.private_fonts.Families[0], 8);

            var key = db.Randoms.Where(c => c.ID == 9).FirstOrDefault();
            txtotherlabel.Text = key.Text.ToString();

            var fee = db.Randoms.Where(c => c.ID == 28).FirstOrDefault();
            txtotherfee.Text = fee.Text.ToString();

            var vouch = db.Randoms.Where(c => c.ID == 31).FirstOrDefault();
            txtvouch.Text = vouch.Text.ToString();

            var late = db.Randoms.Where(c => c.ID == 29).FirstOrDefault();
            txtlate.Text =late.Text.ToString();

            var due = db.Randoms.Where(c => c.ID == 30).FirstOrDefault();
            txtdue.Text = due.Text.ToString();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            var key = db.Randoms.Where(c => c.ID == 9).FirstOrDefault();
            key.Text = txtotherlabel.Text;

            var fee = db.Randoms.Where(c => c.ID == 28).FirstOrDefault();
            fee.Text=txtotherfee.Text;

            var vouch = db.Randoms.Where(c => c.ID == 31).FirstOrDefault();
            vouch.Text = txtvouch.Text;

            var late = db.Randoms.Where(c => c.ID == 29).FirstOrDefault();
            late.Text = txtlate.Text;

            var due = db.Randoms.Where(c => c.ID == 30).FirstOrDefault();
            due.Text = txtdue.Text;

            try
            {
                db.Entry(key).State = System.Data.Entity.EntityState.Modified;
                db.Entry(fee).State = System.Data.Entity.EntityState.Modified;
                db.Entry(vouch).State = System.Data.Entity.EntityState.Modified;
                db.Entry(late).State = System.Data.Entity.EntityState.Modified;
                db.Entry(due).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                labelresult.Text = ex.Message.ToString();
                labelresult.Visible = true;
                labelresult.ForeColor = Color.Red;
            }
            finally
            {
                labelresult.Text = "Successfully Saved!";
                labelresult.Visible = true;
                labelresult.ForeColor = Color.Green;
            }
        }
    }
}
