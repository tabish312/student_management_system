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
using Syncfusion.Windows.Forms;
using Bunifu.Framework.UI;

namespace Student_Management_System
{
    public partial class FeeModify : MetroForm
    {
        DbEntities db = new DbEntities();
        BackgroundWorker bw;
        Loading ld;
        bool done = false;
        string result;
        public FeeModify()
        {
            InitializeComponent();
            this.Icon = global::Student_Management_System.Properties.Resources.icon;
            this.ShowIcon = true;

        }
        private void FeeModify_Load(object sender, EventArgs e)
        {
            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();
            this.CaptionFont = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelresult.Font = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelcopyright.Text = "© Copyright - Student Management Sytem | Powered by TabiSoft Solutions";
            labelcopyright.Font = new Font(EmbedFont.private_fonts.Families[0], 8);


            LoadFees();

        }

        private void btnfeesave_Click(object sender, EventArgs e)
        {
            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            Bitmap bitmap = Student_Management_System.Properties.Resources.loading_f;
            ld = new Loading("Saving", "#EE3322", bitmap);
            ld.Show();
            if (!bw.IsBusy)
            {
                bw.RunWorkerAsync();
            }


        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ld.Hide();
            if (done)
            {
                labelresult.Text = result;
                labelresult.Visible = true;
                labelresult.ForeColor = Color.Green;
            }
            else
            {
                labelresult.Text = result;
                labelresult.Visible = true;
                labelresult.ForeColor = Color.Red;
            }
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            ArrayList ClassArray = new ArrayList();
            ArrayList FeeArray = new ArrayList();


            var clas = db.Randoms.Where(c => c.ID == 26).FirstOrDefault();

            var clasarray = clas.Text.Split(',');

            ClassArray.AddRange(clasarray);


            for (int i = 1; i <= ClassArray.ToArray().Length; i++)
            {
                
                string tfeeName = "tfee" + i.ToString();
                BunifuMetroTextbox tfee_txt = this.Controls.Find(tfeeName, true).FirstOrDefault() as BunifuMetroTextbox;
                

                string efeeName = "efee" + i.ToString();
                BunifuMetroTextbox efee_txt = this.Controls.Find(efeeName, true).FirstOrDefault() as BunifuMetroTextbox;

                string fee = tfee_txt.Text + "," + efee_txt.Text;

                FeeArray.Add(fee);
            }

            string up = String.Join(";", FeeArray.ToArray());

            try
            {
                var fe = db.Randoms.Where(c => c.ID == 32).FirstOrDefault();
                fe.Text = up.ToString();
                db.Entry(fe).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                done = true;
            }
            catch(Exception ex)
            {
                result = ex.Message.ToString();
                done = false;
            }
            finally
            {
                result = "Saved Successfully!";
            }

        }

        private void LoadFees()
        {
            ArrayList ClassArray = new ArrayList();
            ArrayList FeeArrayList = new ArrayList();
            ArrayList TutionFeeArray = new ArrayList();
            ArrayList ExamFeeArray = new ArrayList();

            var clas = db.Randoms.Where(c => c.ID == 26).FirstOrDefault();

            var clasarray = clas.Text.Split(',');

            ClassArray.AddRange(clasarray);

            var fee = db.Randoms.Where(c => c.ID == 32).FirstOrDefault();

            var feearray = fee.Text.ToString().Split(';');

            FeeArrayList.AddRange(feearray);

            for (int i = 0; i <= FeeArrayList.ToArray().Length-1; i++)
            {
                var narray = FeeArrayList[i].ToString().Split(',');
                TutionFeeArray.Add(narray[0].ToString());
                ExamFeeArray.Add(narray[1].ToString());
            }


            for (int j = 0; j <= ClassArray.ToArray().Length - 1; j++)
            {
                string className = "txtclass" + (j + 1).ToString();
                BunifuMetroTextbox lbl_text = this.Controls.Find(className, true).FirstOrDefault() as BunifuMetroTextbox;
                lbl_text.Text = ClassArray[j].ToString();


                string tfeeName = "tfee" + (j + 1).ToString();
                BunifuMetroTextbox tfee_txt = this.Controls.Find(tfeeName, true).FirstOrDefault() as BunifuMetroTextbox;
                tfee_txt.Text = TutionFeeArray[j].ToString();

                string efeeName = "efee" + (j + 1).ToString();
                BunifuMetroTextbox efee_txt = this.Controls.Find(efeeName, true).FirstOrDefault() as BunifuMetroTextbox;
                efee_txt.Text = ExamFeeArray[j].ToString();
            }
        }
    }
}