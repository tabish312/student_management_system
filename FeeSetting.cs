using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;

namespace Student_Management_System
{
    public partial class FeeSetting : MetroForm
    {
        public static int STUDENT_ID = 0;
        DbEntities db = new DbEntities();
        Bitmap _profileimage_male = Student_Management_System.Properties.Resources.profile_male;
        BackgroundWorker bw;
        FeeModify mod;
        BackgroundWorker bwsearch;
        Loading ld;
        
        int ID;
        string StudentName;
        string FatherName;
        string RegNo;
        bool done;
        string result;
        string name;
        public FeeSetting()
        {
            InitializeComponent();
            this.Icon = global::Student_Management_System.Properties.Resources.icon;
            this.ShowIcon = true;
        }

        private void FeeSetting_Load(object sender, EventArgs e)
        {
            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();
            this.CaptionFont = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelresult.Font = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelcopyright.Text = "© Copyright - Student Management Sytem | Powered by TabiSoft Solutions";
            labelcopyright.Font = new Font(EmbedFont.private_fonts.Families[0], 8);

            sfDataGrid.DataSource = DataSource();
            sfDataGrid.Columns[0].HeaderText = "Class";
            sfDataGrid.Columns[1].HeaderText = "Tution Fee";
            sfDataGrid.Columns[2].HeaderText = "Exam Fee";

            var key = db.Randoms.Where(c => c.ID == 9).FirstOrDefault();
            labelother.Text = key.Text.ToString();

            var fee = db.Randoms.Where(c => c.ID == 28).FirstOrDefault();
            labelotherfee.Text ="Rs. "+ fee.Text.ToString();

            var vouch = db.Randoms.Where(c => c.ID == 31).FirstOrDefault();
            labelvouch.Text = "Rs. " + vouch.Text.ToString();

            var late = db.Randoms.Where(c => c.ID == 29).FirstOrDefault();
            labellate.Text = "Rs. " + late.Text.ToString();

            var due = db.Randoms.Where(c => c.ID == 30).FirstOrDefault();
            labeldue.Text = due.Text.ToString() + " of Every Month";
        }

        private System.Data.DataTable DataSource(string Name = null)
        {
            ArrayList ClassArray = new ArrayList();
            ArrayList FeeArray = new ArrayList();
            ArrayList TutionFeeArray = new ArrayList();
            ArrayList ExamFeeArray = new ArrayList();

            var classes = db.Randoms.Where(c => c.ID == 26).FirstOrDefault();
            ClassArray.AddRange(classes.Text.Split(','));

            var fee = db.Randoms.Where(c => c.ID == 32).FirstOrDefault();
            var feearray = fee.Text.Split(';');

            FeeArray.AddRange(feearray);

            for (int i = 0; i <= FeeArray.ToArray().Length - 1; i++)
            {
                var narray = FeeArray[i].ToString().Split(',');
                TutionFeeArray.Add(narray[0].ToString());
                ExamFeeArray.Add(narray[1].ToString());
            }

            System.Data.DataTable custTable = new System.Data.DataTable("FeesWithClass");
            DataColumn dtColumn;
            DataRow myDataRow;
            DataSet dtSet;

            // Create id column  
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Class";
            dtColumn.Caption = "Class";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create Name column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "TutionFee";
            dtColumn.Caption = "TutionFee";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            /// Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create Address column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "ExamFee";
            dtColumn.Caption = "ExamFee";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.    
            custTable.Columns.Add(dtColumn);

            // Create a new DataSet  
            dtSet = new DataSet();

            // Add custTable to the DataSet.    
            dtSet.Tables.Add(custTable);


            for (int x = 0; x <= ClassArray.ToArray().Length - 1; x++)
            {


                myDataRow = custTable.NewRow();

                myDataRow["Class"] = ClassArray[x].ToString();

                myDataRow["TutionFee"] = "Rs. " + TutionFeeArray[x].ToString();

                myDataRow["ExamFee"] = "Rs. " + ExamFeeArray[x].ToString();

                custTable.Rows.Add(myDataRow);
            }

            return custTable;

        }

        private void btnfeemodify_Click(object sender, EventArgs e)
        {
            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            Bitmap bitmap = Student_Management_System.Properties.Resources.loading_f;
            
            if(!bw.IsBusy)
            {
                bw.RunWorkerAsync();
            }
            
            
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mod.ShowDialog();
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
             mod = new FeeModify();
        }

        private void FeeSetting_Activated(object sender, EventArgs e)
        {
            DbEntityRefresh.Refresh(db);
            FeeSetting_Load(sender, e);
        }

        private void btnothersfee_Click(object sender, EventArgs e)
        {
            ModifyOthersFee modifyOthersFee = new ModifyOthersFee();
            modifyOthersFee.ShowDialog();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            bwsearch = new BackgroundWorker();
            bwsearch.DoWork += Bwsearch_DoWork;
            bwsearch.RunWorkerCompleted += Bwsearch_RunWorkerCompleted;

            name = txtstdname.Text;
            name = Regex.Replace(name, @"(^\w)|(\s\w)", m => m.Value.ToUpper());

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
                STUDENT_ID = ID;
                labelresult.Visible = false;
                ModifyStudentFee modifyStudentFee = new ModifyStudentFee(STUDENT_ID);
                modifyStudentFee.ShowDialog();
            }
            else
            {
                labelresult.Text = result;
                labelresult.ForeColor = Color.Red;
                labelresult.Visible = true;
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
                    var det = db.StudentDatas.Where(c => c.StudentName == name).FirstOrDefault();

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
                        var det = db.StudentDatas.Where(c => c.ID == id && c.StudentName == name).FirstOrDefault();

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
                    var det = db.StudentDatas.Where(c => c.RegNo == txtregno.Text && c.StudentName == name).FirstOrDefault();

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
    }
}
