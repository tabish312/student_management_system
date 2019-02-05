using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Windows.Forms;

namespace Student_Management_System
{
    public partial class StaffSubmission : MetroForm
    {
        DbEntities db = new DbEntities();
        BackgroundWorker bwgento;
        BackgroundWorker bwgenmon;
        Loading ld;
        private static object locker = new Object();
        public StaffSubmission()
        {
            InitializeComponent();
            this.Icon = global::Student_Management_System.Properties.Resources.icon;
            this.ShowIcon = true;
        }

        private void StaffSubmission_Load(object sender, EventArgs e)
        {
            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();
            this.CaptionFont = new System.Drawing.Font(EmbedFont.private_fonts.Families[2], 9);
            labeltoday.Font = new System.Drawing.Font(EmbedFont.private_fonts.Families[0], 10);
            labelmonth.Font = new System.Drawing.Font(EmbedFont.private_fonts.Families[0], 10);
            labeltotaltoday.Font = new System.Drawing.Font(EmbedFont.private_fonts.Families[0], 12, FontStyle.Bold);
            labeltotalmonth.Font = new System.Drawing.Font(EmbedFont.private_fonts.Families[0], 12, FontStyle.Bold);
            labelschool.Font = new System.Drawing.Font(EmbedFont.private_fonts.Families[0], 16);
            labeltotalmonth.Text = "Rs. " + TotalAmountPerMonth() + "/-";
            labeltotaltoday.Text = "Rs. " + TotalAmountToday() + "/-";
            sfDataGrid.DataSource = DataTable();
            sfDataGrid.Columns[0].HeaderText = "Student Name";
            sfDataGrid.Columns[1].HeaderText = "Father's Name";
            sfDataGrid.Columns[2].HeaderText = "Amount";
            sfDataGrid.Columns[3].HeaderText = "Date & Time";

            labelcopyright.Text = "© Copyright - Student Management Sytem | Powered by TabiSoft Solutions";
            labelcopyright.Font = new System.Drawing.Font(EmbedFont.private_fonts.Families[0], 8);
            labelresult.Font = new System.Drawing.Font(EmbedFont.private_fonts.Families[2], 9);

        }



        public string TotalAmountPerMonth()
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

            var amount = db.Randoms.Where(c => c.ID == 5).FirstOrDefault();
            var amountarray = amount.Text.Split(',');
            return amountarray[index].ToString();
        }

        public string TotalAmountToday()
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

            var dates = db.Randoms.Where(c => c.ID == 7).FirstOrDefault();
            var datearray = dates.Text.Split(';');

            var marray = datearray[index].Split(',');

            var amounts = db.Randoms.Where(c => c.ID == 6).FirstOrDefault();
            var amountarray = amounts.Text.Split(';');

            var amarray = amountarray[index].Split(',');

            ArrayList marrayList = new ArrayList();
            marrayList.AddRange(marray);

            ArrayList amarrayList = new ArrayList();
            amarrayList.AddRange(amarray);

            int today = 0;

            for (int i = 0; i <= marrayList.ToArray().Length - 2; i++)
            {
                DateTime date = DateTime.ParseExact(marrayList[i].ToString(), "dd/MM/yyyy hh:mm tt", null);

                string day = date.ToString("dd");

                if (DateTime.Now.ToString("dd") == day)
                {
                    today = today + (Convert.ToInt32(amarrayList[i]));
                }
            }





            return today.ToString();
        }

        public class FeeSub
        {
            public string Name { get; set; }

            public string FatherName { get; set; }

            public string Amount { get; set; }

            public string DateTime { get; set; }
        }

        public System.Data.DataTable DataTable()
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

            var dates = db.Randoms.Where(c => c.ID == 7).FirstOrDefault();
            var datearray = dates.Text.Split(';');
            var marray = datearray[index].Split(',');

            var amounts = db.Randoms.Where(c => c.ID == 6).FirstOrDefault();
            var amountarray = amounts.Text.Split(';');
            var amarray = amountarray[index].Split(',');

            var names = db.Randoms.Where(c => c.ID == 8).FirstOrDefault();
            var namearray = names.Text.Split(';');
            var narray = namearray[index].Split(',');

            ArrayList marrayList = new ArrayList();
            marrayList.AddRange(marray);

            ArrayList amarrayList = new ArrayList();
            amarrayList.AddRange(amarray);

            ArrayList narraylist = new ArrayList();
            narraylist.AddRange(narray);

            ArrayList farrayList = new ArrayList();

            for (int i = 0; i <= narraylist.ToArray().Length - 2; i++)
            {
                string a = narraylist[i].ToString();
                var data = db.StudentDatas.Where(c => c.StudentName == a).FirstOrDefault();
                farrayList.Add(data.FatherName);
            }

            System.Data.DataTable custTable = new System.Data.DataTable("FeeSub");
            DataColumn dtColumn;
            DataRow myDataRow;
            DataSet dtSet;

            // Create id column  
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Name";
            dtColumn.Caption = "Student Name";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create Name column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "FatherName";
            dtColumn.Caption = "Father's Name";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            /// Add column to the DataColumnCollection.  
            custTable.Columns.Add(dtColumn);

            // Create Address column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Amount";
            dtColumn.Caption = "Amount";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.    
            custTable.Columns.Add(dtColumn);

            // Create Address column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "DateTime";
            dtColumn.Caption = "Date & Time";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.    
            custTable.Columns.Add(dtColumn);



            // Create a new DataSet  
            dtSet = new DataSet();

            // Add custTable to the DataSet.    
            dtSet.Tables.Add(custTable);

            if (marrayList.ToArray().Length > 0)
            {
                for (int i = 0; i <= marrayList.ToArray().Length - 2; i++)
                {

                    myDataRow = custTable.NewRow();
                    myDataRow["Name"] = narraylist[i].ToString();
                    myDataRow["FatherName"] = farrayList[i].ToString();
                    myDataRow["Amount"] = amarrayList[i].ToString();
                    myDataRow["DateTime"] = marrayList[i].ToString();
                    custTable.Rows.Add(myDataRow);
                }
            }


            return custTable;
        }

        private void btngentoday_Click(object sender, EventArgs e)
        {
            bwgento = new BackgroundWorker();
            bwgento.DoWork += Bwgento_DoWork;
            bwgento.RunWorkerCompleted += Bwgento_RunWorkerCompleted;
            Bitmap btmap = Student_Management_System.Properties.Resources.loading_f;
            ld = new Loading("Generating....", "#EE3322", btmap);

            if (MessageBox.Show("Are you sure you want to generate Today's Report of Fee Submission?", "Confirmation Message - Student Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {

                if (!bwgento.IsBusy)
                {
                    bwgento.RunWorkerAsync();

                    ld.Show();
                }
                else
                {
                    labelresult.Text = "*Printer is busy! Already Printing Today's Report!";
                    labelresult.Visible = true;
                    labelresult.ForeColor = Color.Red;
                }
            }
            else
            {
                return;
            }


        }

        private void Bwgento_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ld.Hide();
        }

        private void Bwgento_DoWork(object sender, DoWorkEventArgs e)
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

                var dates = db.Randoms.Where(c => c.ID == 7).FirstOrDefault();
                var datearray = dates.Text.Split(';');
                var marray = datearray[index].Split(',');

                var amounts = db.Randoms.Where(c => c.ID == 6).FirstOrDefault();
                var amountarray = amounts.Text.Split(';');
                var amarray = amountarray[index].Split(',');

                var names = db.Randoms.Where(c => c.ID == 8).FirstOrDefault();
                var namearray = names.Text.Split(';');
                var narray = namearray[index].Split(',');

                ArrayList marrayList = new ArrayList();
                marrayList.AddRange(marray);

                ArrayList amarrayList = new ArrayList();
                amarrayList.AddRange(amarray);

                ArrayList narraylist = new ArrayList();
                narraylist.AddRange(narray);

                ArrayList farrayList = new ArrayList();

                for (int i = 0; i <= narraylist.ToArray().Length - 2; i++)
                {
                    string a = narraylist[i].ToString();
                    var data = db.StudentDatas.Where(c => c.StudentName == a).FirstOrDefault();
                    farrayList.Add(data.FatherName);
                }

                ArrayList namearrays = new ArrayList();
                ArrayList fathernamearray = new ArrayList();
                ArrayList amountarrays = new ArrayList();
                ArrayList dateandtimearray = new ArrayList();

                for (int i = 0; i <= marrayList.ToArray().Length - 2; i++)
                {
                    DateTime date = DateTime.ParseExact(marrayList[i].ToString(), "dd/MM/yyyy hh:mm tt", null);

                    string day = date.ToString("dd");

                    if (DateTime.Now.ToString("dd") == day)
                    {
                        namearrays.Add(narraylist[i]);
                        fathernamearray.Add(farrayList[i]);
                        amountarrays.Add(amarray[i]);
                        dateandtimearray.Add(marrayList[i]);
                    }
                }

                try
                {
                    WordDocument document = new WordDocument(System.Windows.Forms.Application.StartupPath + @"\Samples\submission_sample.docx", FormatType.Docx);

                    var schoolname = db.Randoms.Where(c => c.ID == 1).FirstOrDefault();
                    var address = db.Randoms.Where(c => c.ID == 2).FirstOrDefault();
                    var contact = db.Randoms.Where(c => c.ID == 3).FirstOrDefault();
                    var email = db.Randoms.Where(c => c.ID == 4).FirstOrDefault();

                    #region SchoolName
                    TextSelection textSelection = document.Find("{SchoolName}", false, true);
                    IWTextRange textRange = textSelection.GetAsOneRange();

                    //Modifies the text

                    textRange.Text = schoolname.Text.ToString();
                    textRange.CharacterFormat.FontName = "Times New Roman";
                    #endregion

                    #region Address
                    textSelection = document.Find("{Address}", false, true);
                    WTextRange addr = textSelection.GetAsOneRange();

                    addr.Text = address.Text.ToString();

                    #endregion

                    #region Contact
                    textSelection = document.Find("{Contact}", false, true);
                    WTextRange con = textSelection.GetAsOneRange();

                    con.Text = contact.Text.ToString();
                    #endregion

                    #region Email
                    textSelection = document.Find("{Email}", false, true);
                    WTextRange Email = textSelection.GetAsOneRange();

                    Email.Text = email.Text.ToString();
                    #endregion

                    #region DateMonth
                    textSelection = document.Find("{DateMonth}", false, true);
                    WTextRange DateMonth = textSelection.GetAsOneRange();

                    DateMonth.Text = "Date";
                    #endregion

                    #region MonthDate
                    textSelection = document.Find("{MonthDate}", false, true);

                    WTextRange MonthDate = textSelection.GetAsOneRange();

                    MonthDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    #endregion

                    #region Time
                    textSelection = document.Find("{Time}", false, true);

                    WTextRange Time = textSelection.GetAsOneRange();

                    Time.Text = DateTime.Now.ToString("hh:mm tt");
                    #endregion

                    #region Amount

                    int amt = 0;
                    for(int i=0;i<=amountarrays.ToArray().Length-1;i++)
                    {
                        amt = amt + Convert.ToInt32(amountarrays[i]);
                    }
                    textSelection = document.Find("{Amount}", false, true);

                    WTextRange Amount = textSelection.GetAsOneRange();

                    Amount.Text = "Rs. "+amt.ToString();
                    #endregion

                    IWSection section = document.Sections[0];
                    IWTable table = section.AddTable();

                    table.ResetCells(namearrays.ToArray().Length + 1, 4);

                    //Header 1
                    IWParagraph wParagraph = table[0, 0].AddParagraph();
                    wParagraph.ParagraphFormat.AfterSpacing = 2f;
                    wParagraph.ParagraphFormat.BeforeSpacing = 2f;
                    wParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Left;
                    textRange = wParagraph.AppendText("Student’s Name");
                    textRange.CharacterFormat.FontName = "Century Gothic";
                    textRange.CharacterFormat.FontSize = 9;
                    textRange.CharacterFormat.Bold = true;


                    //Header 2
                    wParagraph = table[0, 1].AddParagraph();
                    wParagraph.ParagraphFormat.AfterSpacing = 2f;
                    wParagraph.ParagraphFormat.BeforeSpacing = 2f;
                    wParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Left;
                    textRange = wParagraph.AppendText("Father's Name");
                    textRange.CharacterFormat.FontName = "Century Gothic";
                    textRange.CharacterFormat.FontSize = 9;
                    textRange.CharacterFormat.Bold = true;

                    //Header 3
                    wParagraph = table[0, 2].AddParagraph();
                    wParagraph.ParagraphFormat.AfterSpacing = 2f;
                    wParagraph.ParagraphFormat.BeforeSpacing = 2f;
                    wParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    textRange = wParagraph.AppendText("Amount");
                    textRange.CharacterFormat.FontName = "Century Gothic";
                    textRange.CharacterFormat.FontSize = 9;
                    textRange.CharacterFormat.Bold = true;

                    //Header 4
                    wParagraph = table[0, 3].AddParagraph();
                    wParagraph.ParagraphFormat.AfterSpacing = 2f;
                    wParagraph.ParagraphFormat.BeforeSpacing = 2f;
                    wParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    textRange = wParagraph.AppendText("Date & Time");
                    textRange.CharacterFormat.FontName = "Century Gothic";
                    textRange.CharacterFormat.FontSize = 9;
                    textRange.CharacterFormat.Bold = true;

                    for (int i = 0; i <= namearrays.ToArray().Length - 1; i++)
                    {
                        int inc = i + 1;
                        //Column 1
                        wParagraph = table[inc, 0].AddParagraph();
                        wParagraph.ParagraphFormat.AfterSpacing = 2f;
                        wParagraph.ParagraphFormat.BeforeSpacing = 2f;
                        wParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Left;
                        textRange = wParagraph.AppendText(namearrays[i].ToString());
                        textRange.CharacterFormat.FontName = "Century Gothic";
                        textRange.CharacterFormat.FontSize = 9;
                        textRange.CharacterFormat.Bold = false;


                        //Column 2
                        wParagraph = table[inc, 1].AddParagraph();
                        wParagraph.ParagraphFormat.AfterSpacing = 2f;
                        wParagraph.ParagraphFormat.BeforeSpacing = 2f;
                        wParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Left;
                        textRange = wParagraph.AppendText(fathernamearray[i].ToString());
                        textRange.CharacterFormat.FontName = "Century Gothic";
                        textRange.CharacterFormat.FontSize = 9;
                        textRange.CharacterFormat.Bold = false;

                        //Column 3
                        wParagraph = table[inc, 2].AddParagraph();
                        wParagraph.ParagraphFormat.AfterSpacing = 2f;
                        wParagraph.ParagraphFormat.BeforeSpacing = 2f;
                        wParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                        textRange = wParagraph.AppendText(amountarrays[i].ToString());
                        textRange.CharacterFormat.FontName = "Century Gothic";
                        textRange.CharacterFormat.FontSize = 9;
                        textRange.CharacterFormat.Bold = false;

                        //Column 4
                        wParagraph = table[inc, 3].AddParagraph();
                        wParagraph.ParagraphFormat.AfterSpacing = 2f;
                        wParagraph.ParagraphFormat.BeforeSpacing = 2f;
                        wParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                        textRange = wParagraph.AppendText(dateandtimearray[i].ToString());
                        textRange.CharacterFormat.FontName = "Century Gothic";
                        textRange.CharacterFormat.FontSize = 9;
                        textRange.CharacterFormat.Bold = false;
                    }


                    string savepath = "FeeSubmissionList-" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".docx";
                    document.Save(savepath, FormatType.Docx);
                    
                    PrintWord(System.Windows.Forms.Application.StartupPath + @"\" + savepath, "Microsoft Print to PDF");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            

        }


        
        private void btngenmonth_Click(object sender, EventArgs e)
        {
            bwgenmon = new BackgroundWorker();
            bwgenmon.DoWork += Bwgenmon_DoWork;
            bwgenmon.RunWorkerCompleted += Bwgenmon_RunWorkerCompleted;
            Bitmap btmap = Student_Management_System.Properties.Resources.loading_f;

            if (MessageBox.Show("Are you sure you want to generate Monthly Report of Fee Submission?", "Confirmation Message - Student Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {

                if (!bwgenmon.IsBusy)
                {
                    bwgenmon.RunWorkerAsync();
                    ld = new Loading("Generating....", "#EE3322", btmap);
                    ld.Show();

                }
                else
                {
                    labelresult.Text = "*Printer is busy! Already printing Monthly Report!";
                    labelresult.Visible = true;
                    labelresult.ForeColor = Color.Red;
                }
            }
            else
            { return; }
        }

        

        private void Bwgenmon_DoWork(object sender, DoWorkEventArgs e)
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

                var dates = db.Randoms.Where(c => c.ID == 7).FirstOrDefault();
                var datearray = dates.Text.Split(';');
                var marray = datearray[index].Split(',');

                var amounts = db.Randoms.Where(c => c.ID == 6).FirstOrDefault();
                var amountarray = amounts.Text.Split(';');
                var amarray = amountarray[index].Split(',');

                var names = db.Randoms.Where(c => c.ID == 8).FirstOrDefault();
                var namearray = names.Text.Split(';');
                var narray = namearray[index].Split(',');

                ArrayList marrayList = new ArrayList();
                marrayList.AddRange(marray);

                ArrayList amarrayList = new ArrayList();
                amarrayList.AddRange(amarray);

                ArrayList narraylist = new ArrayList();
                narraylist.AddRange(narray);

                ArrayList farrayList = new ArrayList();

                for (int i = 0; i <= marrayList.ToArray().Length - 2; i++)
                {
                    string a = narraylist[i].ToString();
                    var data = db.StudentDatas.Where(c => c.StudentName == a).FirstOrDefault();
                    farrayList.Add(data.FatherName);
                }
                
                
                try
                {
                    WordDocument document = new WordDocument(System.Windows.Forms.Application.StartupPath + @"\Samples\submission_sample.docx", FormatType.Docx);

                    var schoolname = db.Randoms.Where(c => c.ID == 1).FirstOrDefault();
                    var address = db.Randoms.Where(c => c.ID == 2).FirstOrDefault();
                    var contact = db.Randoms.Where(c => c.ID == 3).FirstOrDefault();
                    var email = db.Randoms.Where(c => c.ID == 4).FirstOrDefault();

                    #region SchoolName
                    TextSelection textSelection = document.Find("{SchoolName}", false, true);
                    IWTextRange textRange = textSelection.GetAsOneRange();

                    //Modifies the text

                    textRange.Text = schoolname.Text.ToString();
                    textRange.CharacterFormat.FontName = "Times New Roman";
                    #endregion

                    #region Address
                    textSelection = document.Find("{Address}", false, true);
                    WTextRange addr = textSelection.GetAsOneRange();

                    addr.Text = address.Text.ToString();

                    #endregion

                    #region Contact
                    textSelection = document.Find("{Contact}", false, true);
                    WTextRange con = textSelection.GetAsOneRange();

                    con.Text = contact.Text.ToString();
                    #endregion

                    #region Email
                    textSelection = document.Find("{Email}", false, true);
                    WTextRange Email = textSelection.GetAsOneRange();

                    Email.Text = email.Text.ToString();
                    #endregion

                    #region DateMonth
                    textSelection = document.Find("{DateMonth}", false, true);
                    WTextRange DateMonth = textSelection.GetAsOneRange();

                    DateMonth.Text = "Month";
                    #endregion

                    #region MonthDate
                    textSelection = document.Find("{MonthDate}", false, true);

                    WTextRange MonthDate = textSelection.GetAsOneRange();

                    MonthDate.Text = DateTime.Now.ToString("MMMM yyyy");
                    #endregion

                    #region Time
                    textSelection = document.Find("{Time}", false, true);

                    WTextRange Time = textSelection.GetAsOneRange();

                    Time.Text = DateTime.Now.ToString("hh:mm tt");
                    #endregion

                    #region Amount

                    int amt = 0;
                    for (int i = 0; i <= amarrayList.ToArray().Length - 2; i++)
                    {
                        amt = amt + Convert.ToInt32(amarrayList[i]);
                    }
                    textSelection = document.Find("{Amount}", false, true);

                    WTextRange Amount = textSelection.GetAsOneRange();

                    Amount.Text = "Rs. " + amt.ToString();
                    #endregion

                    IWSection section = document.Sections[0];

                    
                    IWTable table = section.AddTable();

                    table.ResetCells(farrayList.ToArray().Length+1, 4);

                    //Header 1
                    IWParagraph wParagraph = table[0, 0].AddParagraph();
                    wParagraph.ParagraphFormat.AfterSpacing = 2f;
                    wParagraph.ParagraphFormat.BeforeSpacing = 2f;
                    wParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Left;
                    textRange = wParagraph.AppendText("Student’s Name");
                    textRange.CharacterFormat.FontName = "Century Gothic";
                    textRange.CharacterFormat.FontSize = 9;
                    textRange.CharacterFormat.Bold = true;


                    //Header 2
                    wParagraph = table[0, 1].AddParagraph();
                    wParagraph.ParagraphFormat.AfterSpacing = 2f;
                    wParagraph.ParagraphFormat.BeforeSpacing = 2f;
                    wParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Left;
                    textRange = wParagraph.AppendText("Father's Name");
                    textRange.CharacterFormat.FontName = "Century Gothic";
                    textRange.CharacterFormat.FontSize = 9;
                    textRange.CharacterFormat.Bold = true;

                    //Header 3
                    wParagraph = table[0, 2].AddParagraph();
                    wParagraph.ParagraphFormat.AfterSpacing = 2f;
                    wParagraph.ParagraphFormat.BeforeSpacing = 2f;
                    wParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    textRange = wParagraph.AppendText("Amount");
                    textRange.CharacterFormat.FontName = "Century Gothic";
                    textRange.CharacterFormat.FontSize = 9;
                    textRange.CharacterFormat.Bold = true;

                    //Header 4
                    wParagraph = table[0, 3].AddParagraph();
                    wParagraph.ParagraphFormat.AfterSpacing = 2f;
                    wParagraph.ParagraphFormat.BeforeSpacing = 2f;
                    wParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    textRange = wParagraph.AppendText("Date & Time");
                    textRange.CharacterFormat.FontName = "Century Gothic";
                    textRange.CharacterFormat.FontSize = 9;
                    textRange.CharacterFormat.Bold = true;

                    
                    for (int i = 0; i <= farrayList.ToArray().Length - 1; i++)
                    {
                        int inc = i + 1;
                        //Column 1
                        wParagraph = table[inc, 0].AddParagraph();
                        wParagraph.ParagraphFormat.AfterSpacing = 2f;
                        wParagraph.ParagraphFormat.BeforeSpacing = 2f;
                        wParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Left;
                        textRange = wParagraph.AppendText(narraylist[i].ToString());
                        textRange.CharacterFormat.FontName = "Century Gothic";
                        textRange.CharacterFormat.FontSize = 9;
                        textRange.CharacterFormat.Bold = false;


                        //Column 2
                        wParagraph = table[inc, 1].AddParagraph();
                        wParagraph.ParagraphFormat.AfterSpacing = 2f;
                        wParagraph.ParagraphFormat.BeforeSpacing = 2f;
                        wParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Left;
                        textRange = wParagraph.AppendText(farrayList[i].ToString());
                        textRange.CharacterFormat.FontName = "Century Gothic";
                        textRange.CharacterFormat.FontSize = 9;
                        textRange.CharacterFormat.Bold = false;

                        //Column 3
                        wParagraph = table[inc, 2].AddParagraph();
                        wParagraph.ParagraphFormat.AfterSpacing = 2f;
                        wParagraph.ParagraphFormat.BeforeSpacing = 2f;
                        wParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                        textRange = wParagraph.AppendText(amarrayList[i].ToString());
                        textRange.CharacterFormat.FontName = "Century Gothic";
                        textRange.CharacterFormat.FontSize = 9;
                        textRange.CharacterFormat.Bold = false;

                        //Column 4
                        wParagraph = table[inc, 3].AddParagraph();
                        wParagraph.ParagraphFormat.AfterSpacing = 2f;
                        wParagraph.ParagraphFormat.BeforeSpacing = 2f;
                        wParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                        textRange = wParagraph.AppendText(marrayList[i].ToString());
                        textRange.CharacterFormat.FontName = "Century Gothic";
                        textRange.CharacterFormat.FontSize = 9;
                        textRange.CharacterFormat.Bold = false;
                    }
                    

                    string savepath = "FeeSubmissionList-" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".docx";
                    document.Save(savepath, FormatType.Docx);
                    
                    

                    PrintWord(System.Windows.Forms.Application.StartupPath + @"\" + savepath, "Microsoft Print to PDF");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }

        private void Bwgenmon_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ld.Hide();
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