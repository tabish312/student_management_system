using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;

namespace Student_Management_System
{
    
    public partial class DeleteStudent : MetroForm
    {
        public static int STUDENT_ID = 0;
        public static string name = null;

        Bitmap _profileimage_male = Student_Management_System.Properties.Resources.profile_male;
        DbEntities db = new DbEntities();
        bool done;
        BackgroundWorker bwsearch;
        Loading ld;
        int ID;
        string StudentName;
        string FatherName;
        string RegNo;
        string result;
        public DeleteStudent()
        {
            InitializeComponent();
            this.Icon = global::Student_Management_System.Properties.Resources.icon;
            this.ShowIcon = true;
        }

        private void DeleteStudent_Load(object sender, EventArgs e)
        {
            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();
            this.CaptionFont = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelcopyright.Text = "© Copyright - Student Management Sytem | Powered by TabiSoft Solutions";
            labelcopyright.Font = new Font(EmbedFont.private_fonts.Families[0], 8);
            labelresult.Font = new Font(EmbedFont.private_fonts.Families[2], 9);
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            bwsearch = new BackgroundWorker();
            bwsearch.DoWork += Bwsearch_DoWork;
            bwsearch.RunWorkerCompleted += Bwsearch_RunWorkerCompleted;

            Bitmap btmap = Student_Management_System.Properties.Resources.loading_f;
            ld = new Loading("Searching....", "#EE3322", btmap);
            ld.Show();
            if (!bwsearch.IsBusy)
            {
                bwsearch.RunWorkerAsync();
            }


        }

        private void Bwsearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ld.Hide();
            if (done)
            {
                labelstdid.Text = ID.ToString();
                STUDENT_ID = ID;
                labelstdreg.Text = RegNo;
                labelstdname.Text = StudentName;
                labelfathername.Text = FatherName;
                pictureBoxProfile.Image = ByteToImage(ID);
                labelresult.Visible = false;
            }
            else
            {
                labelresult.Text = result;
                labelresult.ForeColor = Color.Red;
                labelresult.Visible = true;
                labelstdid.Text = "Nil";
                labelstdreg.Text = "Nil";
                labelstdname.Text = "Nil";
                labelfathername.Text = "Nil";
                pictureBoxProfile.Image = _profileimage_male;
            }
        }

        private void Bwsearch_DoWork(object sender, DoWorkEventArgs e)
        {
            done = false;
            if ((txtId.Text != "" && txtId.Text != null) ||
                 (txtregno.Text != "" && txtregno.Text != null) ||
                 (txtstdname.Text != null && txtstdname.Text != ""))
            {

                if (txtId.Text != "" && txtId.Text != null && txtregno.Text == "" && txtstdname.Text == "")
                {
                    int a = 0;
                    bool check = int.TryParse(txtId.Text, out a);
                    if (check)
                    {
                        int id = Convert.ToInt32(txtId.Text);
                        var det = db.StudentDatas.Where(c => c.ID == id).FirstOrDefault();

                        if (det != null)
                        {
                            ID = det.ID;
                            RegNo = det.RegNo;
                            StudentName = det.StudentName;
                            FatherName = det.FatherName;
                            done = true;
                            return;
                        }
                        else
                        {
                            result = "*No record found with given data!";
                        }
                    }
                    else
                    {
                        result = "*Enter ID is not in correct format!";
                    }

                }
                if ((txtregno.Text != "" && txtregno.Text != null) &&
                    (txtId.Text == "") &&
                    (txtstdname.Text == ""))
                {
                    var det = db.StudentDatas.Where(c => c.RegNo == txtregno.Text).FirstOrDefault();

                    if (det != null)
                    {
                        ID = det.ID;
                        RegNo = det.RegNo;
                        StudentName = det.StudentName;
                        FatherName = det.FatherName;
                        done = true;
                        return;
                    }
                    else
                    {
                        result = "*No record found with given data!";
                    }
                }
                if ((txtstdname.Text != "" && txtstdname.Text != null) &&
                    (txtregno.Text == "") &&
                    (txtId.Text == ""))
                {
                    var det = db.StudentDatas.Where(c => c.StudentName == txtstdname.Text).FirstOrDefault();

                    if (det != null)
                    {
                        ID = det.ID;
                        RegNo = det.RegNo;
                        StudentName = det.StudentName;
                        FatherName = det.FatherName;
                        done = true;
                        return;
                    }
                    else
                    {
                        result = "*No record found with given data!";
                    }
                }

                if (txtId.Text != "" && txtId.Text != null &&
                txtregno.Text != "" &&
                (txtstdname.Text == ""))
                {
                    int a = 0;
                    bool check = int.TryParse(txtId.Text, out a);
                    if (check)
                    {
                        int id = Convert.ToInt32(txtId.Text);
                        var det = db.StudentDatas.Where(c => c.ID == id && c.RegNo == txtregno.Text).FirstOrDefault();

                        if (det != null)
                        {
                            ID = det.ID;
                            RegNo = det.RegNo;
                            StudentName = det.StudentName;
                            FatherName = det.FatherName;
                            done = true;
                            return;
                        }
                        else
                        {
                            result = "*No record found with given data!";
                        }
                    }
                    else
                    {
                        result = "*Enter ID is not in correct format!";

                    }
                }

                if (txtId.Text != "" && txtId.Text != null &&
                txtstdname.Text != "" &&
                (txtregno.Text == ""))
                {
                    int a = 0;
                    bool check = int.TryParse(txtId.Text, out a);
                    if (check)
                    {
                        int id = Convert.ToInt32(txtId.Text);
                        var det = db.StudentDatas.Where(c => c.ID == id && c.StudentName == txtstdname.Text).FirstOrDefault();

                        if (det != null)
                        {
                            ID = det.ID;
                            RegNo = det.RegNo;
                            StudentName = det.StudentName;
                            FatherName = det.FatherName;
                            done = true;
                            return;
                        }
                        else
                        {
                            result = "*No record found with given data!";
                        }
                    }
                    else
                    {
                        result = "*Enter ID is not in correct format!";

                    }
                }

                if (txtregno.Text != "" && txtregno.Text != null &&
                txtstdname.Text != "" &&
                (txtId.Text == ""))
                {
                    var det = db.StudentDatas.Where(c => c.RegNo == txtregno.Text && c.StudentName == txtstdname.Text).FirstOrDefault();

                    if (det != null)
                    {
                        ID = det.ID;
                        RegNo = det.RegNo;
                        StudentName = det.StudentName;
                        FatherName = det.FatherName;
                        done = true;
                        return;
                    }
                    else
                    {
                        result = "*No record found with given data!";
                    }
                }

                if (txtregno.Text != "" && txtregno.Text != null &&
                txtstdname.Text != "" && txtstdname.Text != null &&
                (txtId.Text != null && txtId.Text != ""))
                {
                    int a = 0;
                    bool check = int.TryParse(txtId.Text, out a);
                    if (check)
                    {
                        int id = Convert.ToInt32(txtId.Text);
                        var det = db.StudentDatas.Where(c => c.ID == id && c.RegNo == txtregno.Text && c.StudentName == txtstdname.Text).FirstOrDefault();

                        if (det != null)
                        {
                            ID = det.ID;
                            RegNo = det.RegNo;
                            StudentName = det.StudentName;
                            FatherName = det.FatherName;
                            done = true;
                            return;
                        }
                        else
                        {
                            result = "*No record found with given data!";
                        }
                    }
                    else
                    {
                        result = "*Enter ID is not in correct format!";
                    }
                }
            }
            else
            {
                result = "*Enter any one field";
            }
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

        private void btnmodify_Click(object sender, EventArgs e)
        {
            if (STUDENT_ID != 0 && STUDENT_ID > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete record with:\n ID: " + STUDENT_ID + " & Name: " + StudentName + "?", "Confirmation - Studnet Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    try
                    {
                        var i = db.StudentDatas.Where(c => c.ID == STUDENT_ID).FirstOrDefault();
                        var j = db.StudentProfiles.Where(d => d.ID == STUDENT_ID).FirstOrDefault();
                        db.Entry(i).State = System.Data.Entity.EntityState.Deleted;
                        db.Entry(j).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        db.Dispose();
                        MessageBox.Show("Record deleted successfully with ID: " + STUDENT_ID + " & Name: " + name, "Error", MessageBoxButtons.OK);


                    }
                }
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtregno.Text = "";
            txtstdname.Text = "";
            labelstdid.Text = "Nil";
            labelstdreg.Text = "Nil";
            labelstdname.Text = "Nil";
            labelfathername.Text = "Nil";
            pictureBoxProfile.Image = _profileimage_male;
            STUDENT_ID = 0;
            labelresult.Visible = false;

        }

        private void ModifyStudent_Activated(object sender, EventArgs e)
        {
            if(EditForm.RESET)
            {
                btnreset_Click(sender, e);
                DeleteStudent_Load(sender, e);

                var context = ((IObjectContextAdapter)db).ObjectContext;
                var refreshableObjects = db.ChangeTracker.Entries().Select(c => c.Entity).ToList();
                context.Refresh(RefreshMode.StoreWins, refreshableObjects);

            }
        }
    }
}
