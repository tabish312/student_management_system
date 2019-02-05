using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
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
    public partial class FeeSubmission : MetroForm
    {

        public static int STUDENT_ID;
        Bitmap _profileimage_male = Student_Management_System.Properties.Resources.profile_male;
        
        DbEntities db = new DbEntities();

        BackgroundWorker bwsearch;
        Loading ld;
        int ID = 0;
        string StudentName;
        string FatherName;
        string RegNo;
        string tution, transport, exam, others;
        int arrears = 0, total = 0, totaldue = 0, late = 0;
        bool done;
        string name;
        string result;



        public FeeSubmission()
        {
            InitializeComponent();
            this.Icon = global::Student_Management_System.Properties.Resources.icon;
        }


        private void FeeSubmission_Load(object sender, EventArgs e)
        {
            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();
            this.CaptionFont = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelresult.Font = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelcopyright.Text = "© Copyright - Student Management Sytem | Powered by TabiSoft Solutions";
            labelcopyright.Font = new Font(EmbedFont.private_fonts.Families[0], 8);



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

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtregno.Text = "";
            txtstdname.Text = "";
            labelstdid.Text = "Nil";
            labelstdreg.Text = "Nil";
            labelstdname.Text = "Nil";
            labelfathername.Text = "Nil";
            labelmonth.Text = "Nil";
            labeltution.Text = "Nil";
            labeltrans.Text = "Nil";
            labelexam.Text = "Nil";
            labelother.Text = "Nil";
            labelarrears.Text = "Nil";
            labeltotal.Text = "Nil";
            labellate.Text = "Nil";
            labeltotaldue.Text = "Nil";
            labeltotaldue.Text = "Nil";
            txtpaying.Text = "";
            pictureBoxProfile.Image = _profileimage_male;
        }

        private void Bwsearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool submitted = db.StudentFees.Where(c => c.ID == ID).Select(c => c.Submitted).FirstOrDefault();
            ld.Hide();
            if (done)
            {
                if (!submitted)
                {
                    labelstdid.Text = ID.ToString();
                    STUDENT_ID = ID;
                    labelstdreg.Text = RegNo;
                    labelstdname.Text = StudentName;
                    labelfathername.Text = FatherName;
                    labelmonth.Text = DateTime.Now.ToString("MMMM");
                    labeltution.Text = tution.ToString();
                    labeltrans.Text = transport.ToString();
                    labelexam.Text = exam.ToString();
                    labelother.Text = others.ToString();
                    labelarrears.Text = arrears.ToString();
                    labeltotal.Text = "Rs. " + total.ToString() + "/-";
                    labellate.Text = late.ToString();
                    labeltotaldue.Text = "Rs. " + totaldue.ToString() + "/-";
                }
                else
                {
                    labelstdid.Text = ID.ToString();
                    STUDENT_ID = ID;
                    labelstdreg.Text = RegNo;
                    labelstdname.Text = StudentName;
                    labelfathername.Text = FatherName;
                    labelmonth.Text = DateTime.Now.ToString("MMMM");
                    labeltution.Text = "Submitted";
                    labeltrans.Text = "Submitted";
                    labelexam.Text = "Submitted";
                    labelother.Text = "Submitted";
                    labelarrears.Text = arrears.ToString();
                    labeltotal.Text = "Rs. " + total.ToString() + "/-";
                    labellate.Text = late.ToString();
                    labeltotaldue.Text = "Rs. " + totaldue.ToString() + "/-";
                }

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
                labelmonth.Text = "Nil";
                labeltution.Text = "Nil";
                labeltrans.Text = "Nil";
                labelexam.Text = "Nil";
                labelother.Text = "Nil";
                labelarrears.Text = "Nil";
                labeltotal.Text = "Nil";
                labellate.Text = "Nil";
                labeltotaldue.Text = "Nil";
                labeltotaldue.Text = "Nil";
                txtpaying.Text = "";
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
                        var fee = db.StudentFees.Where(c => c.ID == det.ID).FirstOrDefault();
                        var other = db.Randoms.Where(c => c.ID == 28).FirstOrDefault();
                        var ab = db.StudentFees.Where(c => c.ID == det.ID).FirstOrDefault();
                        bool submit = ab.Submitted;
                        if (det != null)
                        {
                            ID = det.ID;
                            RegNo = det.RegNo;
                            StudentName = det.StudentName;
                            FatherName = det.FatherName;
                            tution = TutionFee(id).ToString();
                            transport = fee.TransportFee.ToString();
                            exam = fee.ExamFee.ToString();
                            others = other.Text.ToString();
                            arrears = fee.Arrears;

                            if (!submit)
                            {
                                total = Convert.ToInt32(tution) + Convert.ToInt32(transport) + Convert.ToInt32(exam) + Convert.ToInt32(others) + arrears;
                                var lates = db.Randoms.Where(c => c.ID == 29).FirstOrDefault();

                                late = Convert.ToInt32(lates.Text.ToString());

                                totaldue = total + late;
                            }
                            else
                            {
                                total = arrears;
                                late = 0;
                                totaldue = total;
                            }

                            

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

                    int id = Convert.ToInt32(txtId.Text);
                    var det = db.StudentDatas.Where(c => c.RegNo == txtregno.Text).FirstOrDefault();
                    var fee = db.StudentFees.Where(c => c.ID == det.ID).FirstOrDefault();
                    var other = db.Randoms.Where(c => c.ID == 28).FirstOrDefault();
                    var ab = db.StudentFees.Where(c => c.ID == det.ID).FirstOrDefault();
                    bool submit = ab.Submitted;
                    if (det != null)
                    {
                        ID = det.ID;
                        RegNo = det.RegNo;
                        StudentName = det.StudentName;
                        FatherName = det.FatherName;
                        tution = TutionFee(id).ToString();
                        transport = fee.TransportFee.ToString();
                        exam = fee.ExamFee.ToString();
                        others = other.Text.ToString();
                        arrears = fee.Arrears;

                        if (!submit)
                        {
                            total = Convert.ToInt32(tution) + Convert.ToInt32(transport) + Convert.ToInt32(exam) + Convert.ToInt32(others) + arrears;
                            var lates = db.Randoms.Where(c => c.ID == 29).FirstOrDefault();

                            late = Convert.ToInt32(lates.Text.ToString());

                            totaldue = total + late;
                        }
                        else
                        {
                            total = arrears;
                            late = 0;
                            totaldue = total;
                        }



                        done = true;
                        return;
                    }
                    else
                    {
                        result = "*No record found with given data!";
                    }
                }
            }


            if ((txtstdname.Text != "" && txtstdname.Text != null) &&
                (txtregno.Text == "") &&
                (txtId.Text == ""))
            {

                var det = db.StudentDatas.Where(c => c.StudentName == txtstdname.Text).FirstOrDefault();
                var fee = db.StudentFees.Where(c => c.ID == det.ID).FirstOrDefault();
                var ab = db.StudentFees.Where(c => c.ID == det.ID).FirstOrDefault();
                var other = db.Randoms.Where(c => c.ID == 28).FirstOrDefault();
                bool submit = ab.Submitted;
                if (det != null)
                {
                    ID = det.ID;
                    RegNo = det.RegNo;
                    StudentName = det.StudentName;
                    FatherName = det.FatherName;
                    tution = TutionFee(det.ID).ToString();
                    transport = fee.TransportFee.ToString();
                    exam = fee.ExamFee.ToString();
                    others = other.Text.ToString();
                    arrears = fee.Arrears;

                    if (!submit)
                    {
                        total = Convert.ToInt32(tution) + Convert.ToInt32(transport) + Convert.ToInt32(exam) + Convert.ToInt32(others) + arrears;
                        var lates = db.Randoms.Where(c => c.ID == 29).FirstOrDefault();

                        late = Convert.ToInt32(lates.Text.ToString());

                        totaldue = total + late;
                    }
                    else
                    {
                        total = arrears;
                        late = 0;
                        totaldue = total;
                    }



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
                    var fee = db.StudentFees.Where(c => c.ID == det.ID).FirstOrDefault();
                    var other = db.Randoms.Where(c => c.ID == 28).FirstOrDefault();
                    var ab = db.StudentFees.Where(c => c.ID == det.ID).FirstOrDefault();
                    bool submit = ab.Submitted;
                    if (det != null)
                    {
                        ID = det.ID;
                        RegNo = det.RegNo;
                        StudentName = det.StudentName;
                        FatherName = det.FatherName;
                        tution = TutionFee(id).ToString();
                        transport = fee.TransportFee.ToString();
                        exam = fee.ExamFee.ToString();
                        others = other.Text.ToString();
                        arrears = fee.Arrears;

                        if (!submit)
                        {
                            total = Convert.ToInt32(tution) + Convert.ToInt32(transport) + Convert.ToInt32(exam) + Convert.ToInt32(others) + arrears;
                            var lates = db.Randoms.Where(c => c.ID == 29).FirstOrDefault();

                            late = Convert.ToInt32(lates.Text.ToString());

                            totaldue = total + late;
                        }
                        else
                        {
                            total = arrears;
                            late = 0;
                            totaldue = total;
                        }



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
                    var fee = db.StudentFees.Where(c => c.ID == det.ID).FirstOrDefault();
                    var other = db.Randoms.Where(c => c.ID == 28).FirstOrDefault();
                    var ab = db.StudentFees.Where(c => c.ID == det.ID).FirstOrDefault();
                    bool submit = ab.Submitted;
                    if (det != null)
                    {
                        ID = det.ID;
                        RegNo = det.RegNo;
                        StudentName = det.StudentName;
                        FatherName = det.FatherName;
                        tution = TutionFee(id).ToString();
                        transport = fee.TransportFee.ToString();
                        exam = fee.ExamFee.ToString();
                        others = other.Text.ToString();
                        arrears = fee.Arrears;

                        if (!submit)
                        {
                            total = Convert.ToInt32(tution) + Convert.ToInt32(transport) + Convert.ToInt32(exam) + Convert.ToInt32(others) + arrears;
                            var lates = db.Randoms.Where(c => c.ID == 29).FirstOrDefault();

                            late = Convert.ToInt32(lates.Text.ToString());

                            totaldue = total + late;
                        }
                        else
                        {
                            total = arrears;
                            late = 0;
                            totaldue = total;
                        }



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
                var fee = db.StudentFees.Where(c => c.ID == det.ID).FirstOrDefault();
                var other = db.Randoms.Where(c => c.ID == 28).FirstOrDefault();
                var ab = db.StudentFees.Where(c => c.ID == det.ID).FirstOrDefault();
                bool submit = ab.Submitted;
                if (det != null)
                {
                    ID = det.ID;
                    RegNo = det.RegNo;
                    StudentName = det.StudentName;
                    FatherName = det.FatherName;
                    tution = TutionFee(det.ID).ToString();
                    transport = fee.TransportFee.ToString();
                    exam = fee.ExamFee.ToString();
                    others = other.Text.ToString();
                    arrears = fee.Arrears;

                    if (!submit)
                    {
                        total = Convert.ToInt32(tution) + Convert.ToInt32(transport) + Convert.ToInt32(exam) + Convert.ToInt32(others) + arrears;
                        var lates = db.Randoms.Where(c => c.ID == 29).FirstOrDefault();

                        late = Convert.ToInt32(lates.Text.ToString());

                        totaldue = total + late;
                    }
                    else
                    {
                        total = arrears;
                        late = 0;
                        totaldue = total;
                    }



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
                    var det = db.StudentDatas.Where(c => c.ID == id && c.StudentName == txtstdname.Text && c.RegNo == txtregno.Text).FirstOrDefault();
                    var fee = db.StudentFees.Where(c => c.ID == det.ID).FirstOrDefault();
                    var other = db.Randoms.Where(c => c.ID == 28).FirstOrDefault();
                        var ab = db.StudentFees.Where(c => c.ID == det.ID).FirstOrDefault();
                    bool submit = ab.Submitted;
                    if (det != null)
                    {
                        ID = det.ID;
                        RegNo = det.RegNo;
                        StudentName = det.StudentName;
                        FatherName = det.FatherName;
                        tution = TutionFee(id).ToString();
                        transport = fee.TransportFee.ToString();
                        exam = fee.ExamFee.ToString();
                        others = other.Text.ToString();
                        arrears = fee.Arrears;

                        if (!submit)
                        {
                            total = Convert.ToInt32(tution) + Convert.ToInt32(transport) + Convert.ToInt32(exam) + Convert.ToInt32(others) + arrears;
                            var lates = db.Randoms.Where(c => c.ID == 29).FirstOrDefault();

                            late = Convert.ToInt32(lates.Text.ToString());

                            totaldue = total + late;
                        }
                        else
                        {
                            total = arrears;
                            late = 0;
                            totaldue = total;
                        }



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
            else
            {
                result = "*Enter any one field";
            }
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            int remain = 0;

            int enteredamount;
            bool interger = int.TryParse(txtpaying.Text, out enteredamount);


            if (ID != 0)
            {
                if (interger)
                {
                    if (total != 0 || totaldue != 0)
                    {
                        if (enteredamount != 0 && (enteredamount <= total || enteredamount <= totaldue) && enteredamount > 0)
                        {
                            if (DateTime.Now.Day > 10)
                            {
                                remain = totaldue - enteredamount;

                            }
                            else
                            {
                                remain = total - enteredamount;
                            }

                            try
                            {
                                var stddata = db.StudentDatas.Where(c => c.ID == ID).FirstOrDefault();
                                var stdfee = db.StudentFees.Where(c => c.ID == ID).FirstOrDefault();

                                stddata.Arrears = remain;
                                stdfee.Arrears = remain;
                                stdfee.Submitted = true;
                                stdfee.SubmittedDate = DateTime.Now.ToString("dd/MM/yyyy");



                                if (MessageBox.Show("Are you sure you want to submit fee of " + StudentName + "?", "Fee Submission - Student Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                {
                                    db.Entry(stddata).State = System.Data.Entity.EntityState.Modified;
                                    db.Entry(stdfee).State = System.Data.Entity.EntityState.Modified;
                                    db.SaveChanges();
                                    
                                        FeePerMonth(enteredamount);
                                        FeeSubmit(enteredamount, DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"), StudentName);
                                    
                                    MessageBox.Show("Fee Submitted Succcessfully at " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"), "Fee Submitted - Student Management System", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    btnreset_Click(sender, e);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), "Error - Student Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            labelresult.Text = "*Enter enter a right amount!";
                            labelresult.Visible = true;
                            labelresult.ForeColor = Color.Red;
                        }

                    }
                }
                else
                {
                    labelresult.Text = "*Enter enter a right amount!";
                    labelresult.Visible = true;
                    labelresult.ForeColor = Color.Red;

                }
            }
            else
            {
                labelresult.Text = "*Please search Student first!";
                labelresult.Visible = true;
                labelresult.ForeColor = Color.Red;
            }
        }

        private void txtpaying_OnValueChanged(object sender, EventArgs e)
        {
            if (labelresult.Text == "*Enter enter a right amount!")
            {
                labelresult.Visible = false;
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


        public void FeePerMonth(int feeposting)
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


            var fees = db.Randoms.Where(c => c.ID == 5).FirstOrDefault();

            var feearray = fees.Text.Split(',');

            string a = feearray[index];

            int postedfee = Convert.ToInt32(a);

            int total = postedfee + feeposting;

            ArrayList arrayList = new ArrayList();
            for (int i = 0; i <= 11; i++)
            {
                if (i == index)
                {
                    arrayList.Add(total.ToString());
                }
                else
                {
                    arrayList.Add('0');
                }
            }

            var array = String.Join(",", arrayList.ToArray());

            fees.Text = array.ToString();
            db.Entry(fees).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }


        public void FeeSubmit(int amount, string datetime, string stdname)
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

            var fees = db.Randoms.Where(c => c.ID == 6).FirstOrDefault();
            var date = db.Randoms.Where(c => c.ID == 7).FirstOrDefault();
            var name = db.Randoms.Where(c => c.ID == 8).FirstOrDefault();


            #region Submission Amount
            //For Every Submission of Amount Starts
            var feearray = fees.Text.Split(';');

            string amnt = feearray[index].ToString();

            var nextarray = amnt.Split(',');


            //Every Submission
            ArrayList arrayList = new ArrayList();

            arrayList.AddRange(nextarray);
            arrayList.Reverse();

            //This Point add new amount
            arrayList.Add(amount);

            arrayList.Reverse();

            var firstarray = String.Join(",", arrayList.ToArray());

            ArrayList arrayList2 = new ArrayList();

            arrayList2.AddRange(feearray);
            arrayList2[index] = firstarray.ToString();

            var secondarray = String.Join(";", arrayList2.ToArray());

            //For Every Submission of Amount Ends
            #endregion

            #region Submission Date
            //For Every Submission Date Starts
            var datearray = date.Text.Split(';');

            string dt = datearray[index].ToString();

            var nextarra = dt.Split(',');


            //Every Submission
            ArrayList arrayList3 = new ArrayList();

            arrayList3.AddRange(nextarra);
            arrayList3.Reverse();

            //This Point add new amount
            arrayList3.Add(datetime);

            arrayList3.Reverse();

            var firstarra = String.Join(",", arrayList3.ToArray());

            ArrayList arrayList4 = new ArrayList();

            arrayList4.AddRange(datearray);
            arrayList4[index] = firstarra.ToString();

            var secondaray = String.Join(";", arrayList4.ToArray());

            //For Every Submission Date Ends
            #endregion

            #region Submission Name
            //For Every Submission Date Starts
            var namearray = name.Text.Split(';');

            string names = namearray[index].ToString();

            var allnames = names.Split(',');


            //Every Submission
            ArrayList arrayList5 = new ArrayList();

            arrayList5.AddRange(allnames);
            arrayList5.Reverse();

            //This Point add new amount
            arrayList5.Add(stdname);

            arrayList5.Reverse();

            var mnarray = String.Join(",", arrayList5.ToArray());

            ArrayList arrayList6 = new ArrayList();

            arrayList6.AddRange(namearray);
            arrayList6[index] = mnarray.ToString();

            var final = String.Join(";", arrayList6.ToArray());

            //For Every Submission Name Ends
            #endregion

            fees.Text = secondarray.ToString();
            date.Text = secondaray.ToString();
            name.Text = final.ToString();
            db.Entry(fees).State = System.Data.Entity.EntityState.Modified;
            db.Entry(date).State = System.Data.Entity.EntityState.Modified;
            db.Entry(name).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}