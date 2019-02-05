using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;

namespace Student_Management_System
{
    public partial class ModifyStudentFee : MetroForm
    {
        DbEntities db = new DbEntities();
        public ModifyStudentFee(int ID)
        {
            InitializeComponent();
            this.Icon = global::Student_Management_System.Properties.Resources.icon;
            this.ShowIcon = true;
        }

        private void ModifyStudentFee_Load(object sender, EventArgs e)
        {
            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();
            this.CaptionFont = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelresult.Font = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelcopyright.Text = "© Copyright - Student Management Sytem | Powered by TabiSoft Solutions";
            labelcopyright.Font = new Font(EmbedFont.private_fonts.Families[0], 8);

            var det = db.StudentDatas.Where(c => c.ID == FeeSetting.STUDENT_ID).FirstOrDefault();
            labelstdid.Text = det.ID.ToString();
            labelstdreg.Text = det.RegNo;
            labelstdname.Text = det.StudentName;
            labelfathername.Text = det.FatherName;
            pictureBoxProfile.Image = ByteToImage(det.ID);

            var key = db.Randoms.Where(c => c.ID == 9).FirstOrDefault();
            labelother.Text = key.Text.ToString();

            txttution.Text = TutionFee(det.ID).ToString();

            var fee = db.StudentFees.Where(c => c.ID == det.ID).FirstOrDefault();

            txttransport.Text = fee.TransportFee.ToString();
            txtexam.Text = fee.ExamFee.ToString();

            var otfee = db.Randoms.Where(c => c.ID == 28).FirstOrDefault();
            txtother.Text = otfee.Text.ToString();

        }

        public Bitmap ByteToImage(int id)
        {
            MemoryStream mStream = new MemoryStream();
            var data = db.StudentProfiles.Where(c => c.ID == id).FirstOrDefault();
            byte[] pData = data.Profile;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        public int TutionFee(int id)
        {
            int tutionfee;

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


            var std = db.StudentDatas.Where(c => c.ID == id).FirstOrDefault();
            string fees = std.Fees;

            var feearray = fees.Split(',');

            string mothfee = feearray[index];

            tutionfee = Convert.ToInt32(mothfee);

            return tutionfee;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            var det = db.StudentDatas.Where(c => c.ID == FeeSetting.STUDENT_ID).FirstOrDefault();
            det.Fees = txttution.Text + "," + txttution.Text + "," + txttution.Text + "," + txttution.Text + "," + txttution.Text + "," + txttution.Text + "," + txttution.Text + "," + txttution.Text + "," + txttution.Text + "," + txttution.Text + "," + txttution.Text + "," + txttution.Text;

            var fees = db.StudentFees.Where(c => c.ID == FeeSetting.STUDENT_ID).FirstOrDefault();
            fees.TransportFee = Convert.ToInt32(txttransport.Text);
            fees.ExamFee = Convert.ToInt32(txtexam.Text);
            fees.OthersFee = Convert.ToInt32(txtother.Text);

            try
            {
                db.Entry(det).State = System.Data.Entity.EntityState.Modified;
                db.Entry(fees).State = System.Data.Entity.EntityState.Modified;
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
                labelresult.Text = "Successfully Saved!";
                labelresult.Visible = true;
                labelresult.ForeColor = Color.Green;
            }
        }
    }
}
