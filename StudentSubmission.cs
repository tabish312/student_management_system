using System;
using System.Collections;
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
    public partial class StudentSubmission : MetroForm
    {
        Bitmap _profileimage_male = Student_Management_System.Properties.Resources.profile_male;
        DbEntities db = new DbEntities();
        BackgroundWorker bwsearch;
        Loading ld;
        int ID;
        string StudentName;
        string FatherName;
        string RegNo;
        string name;
        bool done;
        string result;
        public StudentSubmission()
        {
            InitializeComponent();
            this.Icon = global::Student_Management_System.Properties.Resources.icon;
            this.ShowIcon = true;
        }

        private void StudentSubmission_Load(object sender, EventArgs e)
        {
            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();
            this.CaptionFont = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelresult.Font = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelcopyright.Text = "© Copyright - Student Management Sytem | Powered by TabiSoft Solutions";
            labelcopyright.Font = new Font(EmbedFont.private_fonts.Families[0], 8);
            sfDataGrid.DataSource = DataSource();
            sfDataGrid.Columns[0].HeaderText = "Amount";
            sfDataGrid.Columns[1].HeaderText = "Month";
            sfDataGrid.Columns[2].HeaderText = "Date";
        }

        private void sfDataGrid_Click(object sender, EventArgs e)
        {

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
                labelstdreg.Text = RegNo;
                labelstdname.Text = StudentName;
                labelfathername.Text = FatherName;
                pictureBoxProfile.Image = ByteToImage(ID);
                labelresult.Visible = false;
                sfDataGrid.DataSource = DataSource(StudentName);
                sfDataGrid.Columns[0].HeaderText = "Amount";
                sfDataGrid.Columns[1].HeaderText = "Month";
                sfDataGrid.Columns[2].HeaderText = "Date";
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

        private System.Data.DataTable DataSource(string Name=null)
        {
            int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
            ArrayList darrayList = new ArrayList();

            ArrayList amarrayList = new ArrayList();
            string b = null;
            for (int i = 2 - 1; i >= 0; i--)
            {
                var dates = db.Randoms.Where(c => c.ID == 7).FirstOrDefault();
                var datearray = dates.Text.Split(';');
                var marray = datearray[i].Split(',');

                var amounts = db.Randoms.Where(c => c.ID == 6).FirstOrDefault();
                var amountarray = amounts.Text.Split(';');
                var amarray = amountarray[i].Split(',');

                var names = db.Randoms.Where(c => c.ID == 8).FirstOrDefault();
                var namearray = names.Text.Split(';');
                var narray = namearray[i].Split(',');

                b = narray[0].ToString();

                for (int j = 0; j <= narray.Length - 1; j++)
                {
                    if (narray[j].ToString() == Name)
                    {
                        darrayList.Add(marray[j]);
                        amarrayList.Add(amarray[j]);
                    }
                }
            }

            System.Data.DataTable custTable = new System.Data.DataTable("FeeSub");
            DataColumn dtColumn;
            DataRow myDataRow;
            DataSet dtSet;

            // Create id column  
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Amount";
            dtColumn.Caption = "Amount";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create Name column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Month";
            dtColumn.Caption = "Month";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            /// Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create Address column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Date";
            dtColumn.Caption = "Date";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.    
            custTable.Columns.Add(dtColumn);
            
            // Create a new DataSet  
            dtSet = new DataSet();

            // Add custTable to the DataSet.    
            dtSet.Tables.Add(custTable);


            if (darrayList.ToArray().Length > 0)
            {
                for (int x = 0; x <= darrayList.ToArray().Length - 1; x++)
                {
                    DateTime datedata;
                    var datee = DateTime.TryParseExact(darrayList[x].ToString(), "dd/MM/yyyy hh:mm tt", null, System.Globalization.DateTimeStyles.None, out datedata);

                    string monthdata = datedata.ToString("MMMM yyyy");

                    myDataRow = custTable.NewRow();

                    myDataRow["Amount"] = "Rs. " + amarrayList[x].ToString();

                    myDataRow["Month"] = monthdata;

                    string date = darrayList[x].ToString();

                    myDataRow["Date"] = date.Substring(0, 10).ToString();

                    custTable.Rows.Add(myDataRow);
                }
            }

            return custTable;

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
            labelresult.Visible = false;
            StudentSubmission_Load(sender, e);
        }
    }
}
