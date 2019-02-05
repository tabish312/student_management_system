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
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.Drawing.Printing;
using System.Diagnostics;
using Microsoft.Office.Interop.Word;
using System.Collections;

namespace Student_Management_System
{
    public partial class FeeVoucher : MetroForm
    {
        public static int STUDENT_ID = 0;
        Bitmap _profileimage_male = Student_Management_System.Properties.Resources.profile_male;
        DbEntities db = new DbEntities();
        private static object locker = new Object();
        string samplepath = System.Windows.Forms.Application.StartupPath + @"\Sample\";
        BackgroundWorker bw;
        BackgroundWorker bwsearch;
        BackgroundWorker bwprint;
        Loading ld;
        int ID;
        string StudentName;
        string FatherName;
        string RegNo;

        bool done;
        string result;

        int totalfee;
        string tutionfee;
        int nettotal;

        int totaldue;

        public FeeVoucher()
        {
            InitializeComponent();
            this.Icon = global::Student_Management_System.Properties.Resources.icon;
            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();
            this.CaptionFont = new System.Drawing.Font(EmbedFont.private_fonts.Families[2], 9);
            labelcopyright.Text = "© Copyright - Student Management Sytem | Powered by TabiSoft Solutions";
            labelcopyright.Font = new System.Drawing.Font(EmbedFont.private_fonts.Families[0], 8);
            labelresult.Font = new System.Drawing.Font(EmbedFont.private_fonts.Families[2], 9);
            this.ShowIcon = true;

        }


        private void FeeVoucher_Load(object sender, EventArgs e)
        {
            var cls = db.Randoms.Where(c => c.ID == 26).FirstOrDefault();
            var clasarray = cls.Text.Split(',');

            var sec = db.Randoms.Where(c => c.ID == 27).FirstOrDefault();
            var secarray = sec.Text.Split(',');
            
            comboboxclass.DataSource = clasarray;
            comboboxsection.DataSource = secarray;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
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

        private void btnstdprint_Click(object sender, EventArgs e)
        {
            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            Bitmap btmap = Student_Management_System.Properties.Resources.loading_f;
            ld = new Loading("Printing....", "#EE3322", btmap);
            ld.Show();

            if (!bw.IsBusy)
            {
                bw.RunWorkerAsync();
                done = false;
            }
        }

        

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var schoolname = db.Randoms.Where(c => c.ID == 1).FirstOrDefault();
                var address = db.Randoms.Where(c => c.ID == 2).FirstOrDefault();
                var contact = db.Randoms.Where(c => c.ID == 3).FirstOrDefault();
                var email = db.Randoms.Where(c => c.ID == 4).FirstOrDefault();
                var others = db.Randoms.Where(c => c.ID == 9).FirstOrDefault();
                var std = db.StudentDatas.Where(c => c.ID == STUDENT_ID).FirstOrDefault();
                if (std != null)
                {
                    var fee = db.StudentFees.Where(c => c.ID == STUDENT_ID).FirstOrDefault();

                    WordDocument document = new WordDocument(System.Windows.Forms.Application.StartupPath + @"\Samples\fee_sample.docx", FormatType.Docx);


                    #region SchoolName
                    TextSelection textSelection = document.Find("{SchoolName}", false, true);
                    WTextRange textRange = textSelection.GetAsOneRange();

                    //Modifies the text

                    textRange.Text = schoolname.Text.ToString();
                    textRange.CharacterFormat.FontName = "Times New Roman";


                    textSelection = document.Find("{SchoolName}", false, true);
                    WTextRange textRange1 = textSelection.GetAsOneRange();

                    //Modifies the text

                    textRange1.Text = schoolname.Text.ToString();
                    textRange1.CharacterFormat.FontName = "Times New Roman";
                    #endregion

                    #region Address
                    textSelection = document.Find("{Address}", false, true);
                    WTextRange addr = textSelection.GetAsOneRange();

                    addr.Text = address.Text.ToString();

                    textSelection = document.Find("{Address}", false, true);
                    WTextRange addr1 = textSelection.GetAsOneRange();

                    addr1.Text = address.Text.ToString();
                    #endregion

                    #region Contact
                    textSelection = document.Find("{Contact}", false, true);
                    WTextRange con = textSelection.GetAsOneRange();

                    con.Text = contact.Text.ToString();

                    textSelection = document.Find("{Contact}", false, true);
                    WTextRange con1 = textSelection.GetAsOneRange();

                    con1.Text = contact.Text.ToString();
                    #endregion

                    #region Email
                    textSelection = document.Find("{Email}", false, true);
                    WTextRange Email = textSelection.GetAsOneRange();

                    Email.Text = email.Text.ToString();

                    textSelection = document.Find("{Email}", false, true);
                    WTextRange Email1 = textSelection.GetAsOneRange();

                    Email1.Text = email.Text.ToString();
                    #endregion

                    #region ID
                    textSelection = document.Find("{ID}", false, true);
                    WTextRange stdid = textSelection.GetAsOneRange();

                    stdid.Text = std.ID.ToString();

                    textSelection = document.Find("{ID}", false, true);
                    WTextRange stdid1 = textSelection.GetAsOneRange();

                    stdid1.Text = std.ID.ToString();

                    #endregion

                    #region Registration No
                    textSelection = document.Find("{RegNo}", false, true);
                    WTextRange stdreg = textSelection.GetAsOneRange();

                    stdreg.Text = std.RegNo;

                    textSelection = document.Find("{RegNo}", false, true);
                    WTextRange stdreg1 = textSelection.GetAsOneRange();

                    stdreg1.Text = std.RegNo;

                    #endregion

                    #region Class
                    textSelection = document.Find("{ClassSection}", false, true);
                    WTextRange stdclass = textSelection.GetAsOneRange();

                    stdclass.Text = std.Class + " " + std.Section;

                    textSelection = document.Find("{ClassSection}", false, true);
                    WTextRange stdclass1 = textSelection.GetAsOneRange();

                    stdclass1.Text = std.Class + " " + std.Section;

                    #endregion

                    #region Student StudentName
                    textSelection = document.Find("{Name}", false, true);
                    WTextRange stdname = textSelection.GetAsOneRange();

                    stdname.Text = std.StudentName;

                    textSelection = document.Find("{Name}", false, true);
                    WTextRange stdname1 = textSelection.GetAsOneRange();

                    stdname1.Text = std.StudentName;
                    #endregion

                    #region FatherName
                    textSelection = document.Find("{FatherName}", false, true);
                    WTextRange FatherName = textSelection.GetAsOneRange();

                    FatherName.Text = std.FatherName;

                    textSelection = document.Find("{FatherName}", false, true);
                    WTextRange FatherName1 = textSelection.GetAsOneRange();

                    FatherName1.Text = std.Section;
                    #endregion

                    #region DateTime
                    textSelection = document.Find("{Month}{Year}", false, true);
                    WTextRange monthyear = textSelection.GetAsOneRange();

                    monthyear.Text = DateTime.Now.ToString("MMMM yyyy");

                    textSelection = document.Find("{Month}{Year}", false, true);
                    WTextRange monthyear1 = textSelection.GetAsOneRange();

                    monthyear1.Text = DateTime.Now.ToString("MMMM yyyy");

                    textSelection = document.Find("{Month}{Year}", false, true);
                    WTextRange monthyear3 = textSelection.GetAsOneRange();

                    monthyear3.Text = DateTime.Now.ToString("MMMM yyyy");

                    textSelection = document.Find("{Month}{Year}", false, true);
                    WTextRange monthyear4 = textSelection.GetAsOneRange();

                    monthyear4.Text = DateTime.Now.ToString("MMMM yyyy");

                    textSelection = document.Find("{DateTime}", false, true);
                    WTextRange dttime = textSelection.GetAsOneRange();

                    dttime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

                    textSelection = document.Find("{DateTime}", false, true);
                    WTextRange dttime1 = textSelection.GetAsOneRange();

                    dttime1.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                    #endregion

                    #region TutionFee

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



                    string fees = std.Fees;

                    var feearray = fees.Split(',');

                    textSelection = document.Find("{TutionFee}", false, true);
                    WTextRange TutionFee = textSelection.GetAsOneRange();

                    TutionFee.Text = feearray[index].ToString();

                    textSelection = document.Find("{TutionFee}", false, true);
                    WTextRange TutionFee1 = textSelection.GetAsOneRange();

                    TutionFee1.Text = feearray[index].ToString();

                    tutionfee = feearray[index];

                    #endregion

                    #region Arrears
                    textSelection = document.Find("{Arrears}", false, true);
                    WTextRange Arrears = textSelection.GetAsOneRange();

                    Arrears.Text = std.Arrears.ToString();

                    textSelection = document.Find("{Arrears}", false, true);
                    WTextRange Arrears1 = textSelection.GetAsOneRange();

                    Arrears1.Text = std.Arrears.ToString();
                    #endregion

                    #region LateFee
                    var late = db.Randoms.Where(c => c.ID == 29).FirstOrDefault();
                    textSelection = document.Find("{LateFee}", false, true);
                    WTextRange LateFee = textSelection.GetAsOneRange();

                    LateFee.Text = late.Text;

                    textSelection = document.Find("{LateFee}", false, true);
                    WTextRange LateFee1 = textSelection.GetAsOneRange();

                    LateFee1.Text = late.Text;
                    #endregion

                    #region DueDate
                    var due = db.Randoms.Where(c => c.ID == 30).FirstOrDefault();
                    textSelection = document.Find("{DueDate}", false, true);
                    WTextRange DueDate = textSelection.GetAsOneRange();

                    DueDate.Text = due.Text.ToString()+"/" + DateTime.Now.ToString("MM/yyyy");

                    textSelection = document.Find("{DueDate}", false, true);
                    WTextRange DueDate1 = textSelection.GetAsOneRange();

                    DueDate1.Text = due.Text.ToString() + "/" + DateTime.Now.ToString("MM/yyyy");
                    #endregion

                    #region TransportFee
                    textSelection = document.Find("{TransFee}", false, true);
                    WTextRange TransportFee = textSelection.GetAsOneRange();

                    TransportFee.Text = fee.TransportFee.ToString();

                    textSelection = document.Find("{TransFee}", false, true);
                    WTextRange TransportFee1 = textSelection.GetAsOneRange();

                    TransportFee1.Text = fee.TransportFee.ToString();
                    #endregion

                    #region ExamFee
                    textSelection = document.Find("{ExamFee}", false, true);
                    WTextRange ExamFee = textSelection.GetAsOneRange();

                    ExamFee.Text = fee.ExamFee.ToString();

                    textSelection = document.Find("{ExamFee}", false, true);
                    WTextRange ExamFee1 = textSelection.GetAsOneRange();

                    ExamFee1.Text = fee.ExamFee.ToString();
                    #endregion

                    #region OtherFee
                    textSelection = document.Find("{OtherFee}", false, true);
                    WTextRange OtherFee = textSelection.GetAsOneRange();

                    OtherFee.Text = fee.OthersFee.ToString();

                    textSelection = document.Find("{OtherFee}", false, true);
                    WTextRange OtherFee1 = textSelection.GetAsOneRange();

                    OtherFee1.Text = fee.OthersFee.ToString();
                    #endregion

                    #region TotalFee
                    textSelection = document.Find("{TotalFee}", false, true);
                    WTextRange TotalFee = textSelection.GetAsOneRange();
                    totalfee = (Convert.ToInt32(tutionfee)) + fee.TransportFee + fee.ExamFee + fee.OthersFee;
                    TotalFee.Text = totalfee.ToString();

                    textSelection = document.Find("{TotalFee}", false, true);
                    WTextRange TotalFee1 = textSelection.GetAsOneRange();

                    TotalFee1.Text = totalfee.ToString();
                    #endregion

                    #region NetTotal
                    textSelection = document.Find("{NetTotal}", false, true);
                    WTextRange NetTotal = textSelection.GetAsOneRange();

                    nettotal = totalfee + fee.Arrears;
                    NetTotal.Text = nettotal.ToString();

                    textSelection = document.Find("{NetTotal}", false, true);
                    WTextRange NetTotal1 = textSelection.GetAsOneRange();

                    NetTotal1.Text = nettotal.ToString();
                    #endregion

                    #region TotalDueFee
                    textSelection = document.Find("{TotalDueFee}", false, true);
                    WTextRange TotalDueFee = textSelection.GetAsOneRange();

                    totaldue = nettotal + fee.LateFee;
                    TotalDueFee.Text = totaldue.ToString();

                    textSelection = document.Find("{TotalDueFee}", false, true);
                    WTextRange TotalDueFee1 = textSelection.GetAsOneRange();

                    TotalDueFee1.Text = totaldue.ToString();
                    #endregion

                    #region Others Label
                    textSelection = document.Find("{Others}", false, true);
                    WTextRange Others = textSelection.GetAsOneRange();

                    Others.Text = others.Text.ToString();

                    textSelection = document.Find("{Others}", false, true);
                    WTextRange Others1 = textSelection.GetAsOneRange();

                    Others1.Text = others.Text.ToString();
                    #endregion

                    #region Voucher Label
                    var vcfee = db.Randoms.Where(c => c.ID == 31).FirstOrDefault();
                    textSelection = document.Find("{Voucher}", false, true);
                    WTextRange Voucher = textSelection.GetAsOneRange();

                    Voucher.Text = "Rs. " + vcfee.Text + "/-";

                    textSelection = document.Find("{Voucher}", false, true);
                    WTextRange Voucher1 = textSelection.GetAsOneRange();

                    Voucher1.Text = "Rs. " + vcfee.Text + "/-";
                    #endregion



                    string savepath = "Voucher-" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".docx";

                    document.Save(savepath, FormatType.Docx);

                    document.Close();

                    PrintWord(System.Windows.Forms.Application.StartupPath + @"\" + savepath, "Microsoft Print to PDF");

                    done = true;
                    result = "Printing Job Done Successfully!";

                }
                else
                {
                    result = "*No Record Found!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error - Student Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ld.Hide();
            if(done)
            {
                labelresult.Text = result;
                labelresult.Visible = true;
                labelresult.ForeColor = Color.Green;
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

        private void btnstdreset_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtregno.Text = "";
            txtstdname.Text = "";
            labelstdid.Text = "Nil";
            labelstdreg.Text = "Nil";
            labelstdname.Text = "Nil";
            labelfathername.Text = "Nil";
            pictureBoxProfile.Image = _profileimage_male;
        }

        private void btnclassprint_Click(object sender, EventArgs e)
        {
             bwprint = new BackgroundWorker();
                bwprint.DoWork += Bwprint_DoWork;
                bwprint.RunWorkerCompleted += Bwprint_RunWorkerCompleted;

                Bitmap btmap = Student_Management_System.Properties.Resources.loading_f;
                ld = new Loading("Printing....", "#EE3322", btmap);
                ld.Show();
                if (!bwprint.IsBusy)
                {
                    bwprint.RunWorkerAsync();
                }
           
        }



        private void Bwprint_DoWork(object sender, DoWorkEventArgs e)
        {
            if (comboboxclass.Text != "" && comboboxclass.Text != "Select Class" && comboboxsection.Text != "" && comboboxsection.Text != "Select Section")
            {

                var schoolname = db.Randoms.Where(c => c.ID == 1).FirstOrDefault();
                var address = db.Randoms.Where(c => c.ID == 2).FirstOrDefault();
                var contact = db.Randoms.Where(c => c.ID == 3).FirstOrDefault();
                var email = db.Randoms.Where(c => c.ID == 4).FirstOrDefault();
                var others = db.Randoms.Where(c => c.ID == 9).FirstOrDefault();

                var data = db.StudentDatas.Where(c => c.Class == comboboxclass.Text && c.Section == comboboxsection.Text).FirstOrDefault();
                if (data != null)
                {
                    if (MessageBox.Show("Are you Sure you want ot print all the Fee Vouchers of Class: " + comboboxclass.Text + " " + comboboxsection.Text, "Print Confirmation - Student Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        try
                        {
                            ArrayList arrayList = new ArrayList();

                            foreach (var item in db.StudentDatas.Where(c => c.Class == comboboxclass.Text && c.Section == comboboxsection.Text))
                            {
                                arrayList.Add(item.ID);
                            }

                            for (int i = 0; i <= arrayList.ToArray().Length - 1; i++)
                            {
                                int ids = Convert.ToInt32(arrayList[i]);
                                var std = db.StudentDatas.Where(c => c.ID == ids).FirstOrDefault();
                                var fee = db.StudentFees.Where(c => c.ID == ids).FirstOrDefault();

                                
                                WordDocument document = new WordDocument(System.Windows.Forms.Application.StartupPath + @"\Samples\fee_sample.docx", FormatType.Docx);

                                #region SchoolName
                                TextSelection textSelection = document.Find("{SchoolName}", false, true);
                                WTextRange textRange = textSelection.GetAsOneRange();

                                //Modifies the text

                                textRange.Text = schoolname.Text.ToString();
                                textRange.CharacterFormat.FontName = "Times New Roman";


                                textSelection = document.Find("{SchoolName}", false, true);
                                WTextRange textRange1 = textSelection.GetAsOneRange();

                                //Modifies the text

                                textRange1.Text = schoolname.Text.ToString();
                                textRange1.CharacterFormat.FontName = "Times New Roman";
                                #endregion

                                #region Address
                                textSelection = document.Find("{Address}", false, true);
                                WTextRange addr = textSelection.GetAsOneRange();

                                addr.Text = address.Text.ToString();

                                textSelection = document.Find("{Address}", false, true);
                                WTextRange addr1 = textSelection.GetAsOneRange();

                                addr1.Text = address.Text.ToString();
                                #endregion

                                #region Contact
                                textSelection = document.Find("{Contact}", false, true);
                                WTextRange con = textSelection.GetAsOneRange();

                                con.Text = contact.Text.ToString();

                                textSelection = document.Find("{Contact}", false, true);
                                WTextRange con1 = textSelection.GetAsOneRange();

                                con1.Text = contact.Text.ToString();
                                #endregion

                                #region Email
                                textSelection = document.Find("{Email}", false, true);
                                WTextRange Email = textSelection.GetAsOneRange();

                                Email.Text = email.Text.ToString();

                                textSelection = document.Find("{Email}", false, true);
                                WTextRange Email1 = textSelection.GetAsOneRange();

                                Email1.Text = email.Text.ToString();
                                #endregion

                                #region ID
                                textSelection = document.Find("{ID}", false, true);
                                WTextRange stdid = textSelection.GetAsOneRange();

                                stdid.Text = std.ID.ToString();

                                textSelection = document.Find("{ID}", false, true);
                                WTextRange stdid1 = textSelection.GetAsOneRange();

                                stdid1.Text = std.ID.ToString();

                                #endregion

                                #region Registration No
                                textSelection = document.Find("{RegNo}", false, true);
                                WTextRange stdreg = textSelection.GetAsOneRange();

                                stdreg.Text = std.RegNo;

                                textSelection = document.Find("{RegNo}", false, true);
                                WTextRange stdreg1 = textSelection.GetAsOneRange();

                                stdreg1.Text = std.RegNo;

                                #endregion

                                #region Class
                                textSelection = document.Find("{ClassSection}", false, true);
                                WTextRange stdclass = textSelection.GetAsOneRange();

                                stdclass.Text = std.Class + " " + std.Section;

                                textSelection = document.Find("{ClassSection}", false, true);
                                WTextRange stdclass1 = textSelection.GetAsOneRange();

                                stdclass1.Text = std.Class + " " + std.Section;

                                #endregion

                                #region Student StudentName
                                textSelection = document.Find("{Name}", false, true);
                                WTextRange stdname = textSelection.GetAsOneRange();

                                stdname.Text = std.StudentName;

                                textSelection = document.Find("{Name}", false, true);
                                WTextRange stdname1 = textSelection.GetAsOneRange();

                                stdname1.Text = std.StudentName;
                                #endregion

                                #region FatherName
                                textSelection = document.Find("{FatherName}", false, true);
                                WTextRange FatherName = textSelection.GetAsOneRange();

                                FatherName.Text = std.FatherName;

                                textSelection = document.Find("{FatherName}", false, true);
                                WTextRange FatherName1 = textSelection.GetAsOneRange();

                                FatherName1.Text = std.Section;
                                #endregion

                                #region DateTime
                                textSelection = document.Find("{Month}{Year}", false, true);
                                WTextRange monthyear = textSelection.GetAsOneRange();

                                monthyear.Text = DateTime.Now.ToString("MMMM yyyy");

                                textSelection = document.Find("{Month}{Year}", false, true);
                                WTextRange monthyear1 = textSelection.GetAsOneRange();

                                monthyear1.Text = DateTime.Now.ToString("MMMM yyyy");

                                textSelection = document.Find("{Month}{Year}", false, true);
                                WTextRange monthyear3 = textSelection.GetAsOneRange();

                                monthyear3.Text = DateTime.Now.ToString("MMMM yyyy");

                                textSelection = document.Find("{Month}{Year}", false, true);
                                WTextRange monthyear4 = textSelection.GetAsOneRange();

                                monthyear4.Text = DateTime.Now.ToString("MMMM yyyy");

                                textSelection = document.Find("{DateTime}", false, true);
                                WTextRange dttime = textSelection.GetAsOneRange();

                                dttime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

                                textSelection = document.Find("{DateTime}", false, true);
                                WTextRange dttime1 = textSelection.GetAsOneRange();

                                dttime1.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                                #endregion

                                #region TutionFee

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



                                string fees = std.Fees;

                                var feearray = fees.Split(',');

                                textSelection = document.Find("{TutionFee}", false, true);
                                WTextRange TutionFee = textSelection.GetAsOneRange();

                                TutionFee.Text = feearray[index].ToString();

                                textSelection = document.Find("{TutionFee}", false, true);
                                WTextRange TutionFee1 = textSelection.GetAsOneRange();

                                TutionFee1.Text = feearray[index].ToString();

                                tutionfee = feearray[index];

                                #endregion

                                #region Arrears
                                textSelection = document.Find("{Arrears}", false, true);
                                WTextRange Arrears = textSelection.GetAsOneRange();

                                Arrears.Text = fee.Arrears.ToString();

                                textSelection = document.Find("{Arrears}", false, true);
                                WTextRange Arrears1 = textSelection.GetAsOneRange();

                                Arrears1.Text = fee.Arrears.ToString();
                                #endregion

                                #region LateFee
                                textSelection = document.Find("{LateFee}", false, true);
                                WTextRange LateFee = textSelection.GetAsOneRange();

                                LateFee.Text = fee.LateFee.ToString();

                                textSelection = document.Find("{LateFee}", false, true);
                                WTextRange LateFee1 = textSelection.GetAsOneRange();

                                LateFee1.Text = fee.LateFee.ToString();
                                #endregion

                                #region DueDate
                                textSelection = document.Find("{DueDate}", false, true);
                                WTextRange DueDate = textSelection.GetAsOneRange();

                                DueDate.Text = "10/" + DateTime.Now.ToString("MM/yyyy");

                                textSelection = document.Find("{DueDate}", false, true);
                                WTextRange DueDate1 = textSelection.GetAsOneRange();

                                DueDate1.Text = "10/" + DateTime.Now.ToString("MM/yyyy");
                                #endregion

                                #region TransportFee
                                textSelection = document.Find("{TransFee}", false, true);
                                WTextRange TransportFee = textSelection.GetAsOneRange();

                                TransportFee.Text = fee.TransportFee.ToString();

                                textSelection = document.Find("{TransFee}", false, true);
                                WTextRange TransportFee1 = textSelection.GetAsOneRange();

                                TransportFee1.Text = fee.TransportFee.ToString();
                                #endregion

                                #region ExamFee
                                textSelection = document.Find("{ExamFee}", false, true);
                                WTextRange ExamFee = textSelection.GetAsOneRange();

                                ExamFee.Text = fee.ExamFee.ToString();

                                textSelection = document.Find("{ExamFee}", false, true);
                                WTextRange ExamFee1 = textSelection.GetAsOneRange();

                                ExamFee1.Text =fee.ExamFee.ToString();
                                #endregion

                                #region OtherFee
                                textSelection = document.Find("{OtherFee}", false, true);
                                WTextRange OtherFee = textSelection.GetAsOneRange();

                                OtherFee.Text = fee.OthersFee.ToString();

                                textSelection = document.Find("{OtherFee}", false, true);
                                WTextRange OtherFee1 = textSelection.GetAsOneRange();

                                OtherFee1.Text = fee.OthersFee.ToString();
                                #endregion


                                #region TotalFee
                                textSelection = document.Find("{TotalFee}", false, true);
                                WTextRange TotalFee = textSelection.GetAsOneRange();
                                totalfee = (Convert.ToInt32(tutionfee)) + fee.TransportFee + fee.ExamFee + fee.OthersFee;
                                TotalFee.Text = totalfee.ToString();

                                textSelection = document.Find("{TotalFee}", false, true);
                                WTextRange TotalFee1 = textSelection.GetAsOneRange();

                                TotalFee1.Text = totalfee.ToString();
                                #endregion

                                #region NetTotal
                                textSelection = document.Find("{NetTotal}", false, true);
                                WTextRange NetTotal = textSelection.GetAsOneRange();

                                nettotal = totalfee + fee.Arrears;
                                NetTotal.Text = nettotal.ToString();

                                textSelection = document.Find("{NetTotal}", false, true);
                                WTextRange NetTotal1 = textSelection.GetAsOneRange();

                                NetTotal1.Text = nettotal.ToString();
                                #endregion

                                #region TotalDueFee
                                textSelection = document.Find("{TotalDueFee}", false, true);
                                WTextRange TotalDueFee = textSelection.GetAsOneRange();

                                totaldue = nettotal + fee.LateFee;
                                TotalDueFee.Text = totaldue.ToString();

                                textSelection = document.Find("{TotalDueFee}", false, true);
                                WTextRange TotalDueFee1 = textSelection.GetAsOneRange();

                                TotalDueFee1.Text = totaldue.ToString();
                                #endregion

                                #region Others Label
                                textSelection = document.Find("{Others}", false, true);
                                WTextRange Others = textSelection.GetAsOneRange();

                                Others.Text = others.Text.ToString();

                                textSelection = document.Find("{Others}", false, true);
                                WTextRange Others1 = textSelection.GetAsOneRange();

                                Others1.Text = others.Text.ToString();
                                #endregion

                                string savepath = "Voucher-" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".docx";

                                document.Save(savepath, FormatType.Docx);

                                document.Close();

                                PrintWord(System.Windows.Forms.Application.StartupPath + @"\" + savepath, "Microsoft Print to PDF");
                                done = true;
                                result = "Printing Job Done Successfully!";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Error - Student Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    result = "*No Record Found!";
                    done = false;
                }
            }
            else
            {
                result = "*Please Select class and Section!";
                done = false;
            }
        }


        private void Bwprint_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        public void PrintWord(string file, string printer)
        {
            try
            {
                // Kill opened word instances.  
                if (KillProcess("WINWORD"))
                {
                    // Thread safe.  
                    lock (locker)
                    {
                        string fileName = file;
                        string printerName = printer;
                        if (File.Exists(fileName))
                        {
                            Microsoft.Office.Interop.Word.Application _application = new Microsoft.Office.Interop.Word.Application();
                            _application.Application.ActivePrinter = printerName;
                            object oSourceFilePath = (object)fileName;
                            object docType = WdDocumentType.wdTypeDocument;
                            object oFalse = (object)false;
                            object oMissing = System.Reflection.Missing.Value;
                            Document _document = _application.Documents.Open(ref oSourceFilePath,
                                               ref docType,
                                               ref oMissing,
                                               ref oMissing,
                                               ref oMissing,
                                               ref oMissing,
                                               ref oMissing,
                                               ref oMissing,
                                               ref oMissing,
                                               ref oMissing,
                                               ref oMissing,
                                               ref oMissing,
                                               ref oMissing,
                                               ref oMissing,
                                               ref oMissing,
                                               ref oMissing);
                            // Print  
                            _application.PrintOut(ref oFalse, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                              ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                              ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                            object saveOptions = WdSaveOptions.wdDoNotSaveChanges;
                            _document.Close(ref oFalse, ref oMissing, ref oMissing);
                            if (_application != null)
                            {
                                object oSave = false;
                                Object oMiss = System.Reflection.Missing.Value;
                                _application.Quit(ref oSave, ref oMiss, ref oMissing);
                                _application = null;
                            }
                            // Delete the file once it is printed  
                            File.Delete(fileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                KillProcess("WINWORD");
                MessageBox.Show(ex.Message.ToString(), "Error while Printing - Student Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
            }
        }
        private static bool KillProcess(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses().Where(p => p.ProcessName.Contains(name)))
            {
                if (Process.GetCurrentProcess().Id == clsProcess.Id)
                    continue;
                if (clsProcess.ProcessName.Contains(name))
                {
                    clsProcess.Kill();
                    return true;
                }
            }
            return true;
        }
    }
}

