using Microsoft.Office.Interop.Word;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
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
using Word = Microsoft.Office.Interop.Word;
using Syncfusion.Windows.Forms;


namespace Student_Management_System
{
    public partial class FeeDefaulters : MetroForm
    {
        DbEntities db = new DbEntities();
        BackgroundWorker bwsearch;
        Loading ld;
        string result, totalstudents, totalsubmit, totaldef;
        bool done = false;
        ArrayList IDArrays;
        ArrayList DefaultArray;
        BackgroundWorker bwprint;
        private static object locker = new Object();

        public FeeDefaulters()
        {
            InitializeComponent();
            this.Icon = global::Student_Management_System.Properties.Resources.icon;
            this.ShowIcon = true;
        }

        private void FeeDefaulters_Load(object sender, EventArgs e)
        {
            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();
            this.CaptionFont = new System.Drawing.Font(EmbedFont.private_fonts.Families[2], 9);
            labelresult.Font = new System.Drawing.Font(EmbedFont.private_fonts.Families[2], 9);
            labelcopyright.Text = "© Copyright - Student Management Sytem | Powered by TabiSoft Solutions";
            labelcopyright.Font = new System.Drawing.Font(EmbedFont.private_fonts.Families[0], 8);

            string[] classes = { "Prep", "Nursery", "KG", "Montessori", "1st", "2nd", "3rd", "4th", "5th", "6th", "7th" };
            string[] section = { "A", "B", "C", "D" };
            comboboxclass.DataSource = classes;
            comboboxsection.DataSource = section;
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
                labelstd.Text = totalstudents;
                labelstddef.Text = totaldef;
                labelstdsub.Text = totalsubmit;
            }
            else
            {
                labelresult.Text = result;
                labelresult.Visible = true;
                labelresult.ForeColor = Color.Red;
            }

        }

        private void Bwsearch_DoWork(object sender, DoWorkEventArgs e)
        {
            if (comboboxclass.Text != "" && comboboxclass.Text != "Select Class" && comboboxsection.Text != "" && comboboxsection.Text != "Select Section")
            {
                done = true;

                IDArrays = new ArrayList();

                foreach (var item in db.StudentDatas.Where(c => c.Class == comboboxclass.Text && c.Section == comboboxsection.Text))
                {
                    IDArrays.Add(item.ID);
                }

                DefaultArray = new ArrayList();


                for (int i = 0; i <= IDArrays.ToArray().Length - 1; i++)
                {
                    int ids = Convert.ToInt32(IDArrays[i]);
                    var a = db.StudentFees.Where(c => c.ID == ids && c.Submitted == false).FirstOrDefault();
                    if (a != null)
                    {
                        DefaultArray.Add(a.ID);
                    }
                }


                totalstudents = IDArrays.ToArray().Length.ToString();
                totaldef = DefaultArray.ToArray().Length.ToString();
                int x = Convert.ToInt32(totalstudents) - Convert.ToInt32(totaldef);
                totalsubmit = x.ToString();
            }
            else
            {
                done = false;


                result = "*Please Select a Class and Section!";

            }
        }

        private void btnprint_Click(object sender, EventArgs e)
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

        private void Bwprint_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ld.Hide();
            if(done)
            {
                labelstd.Text = "Nil";
                labelstddef.Text = "Nil";
                labelstdsub.Text = "Nil";
            }
        }

        private void Bwprint_DoWork(object sender, DoWorkEventArgs e)
        {
            if (done)
            {
                try
                {
                    WordDocument document = new WordDocument(System.Windows.Forms.Application.StartupPath + @"\Samples\defaulters_sample.docx", FormatType.Docx);

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

                    #region Class Section
                    textSelection = document.Find("{ClassSection}", false, true);
                    WTextRange classsection = textSelection.GetAsOneRange();

                    classsection.Text = comboboxclass.Text + " " + comboboxsection.Text;
                    #endregion

                    #region Month Year
                    textSelection = document.Find("{MonthYear}", false, true);

                    WTextRange MonthYear = textSelection.GetAsOneRange();

                    MonthYear.Text = DateTime.Now.ToString("MMMM yyyy");
                    #endregion

                    #region Total Defaulters
                    textSelection = document.Find("{Defaulters}", false, true);

                    WTextRange Defaulters = textSelection.GetAsOneRange();

                    Defaulters.Text = DefaultArray.ToArray().Length.ToString();
                    #endregion



                    IWSection section = document.Sections[0];
                    IWTable table = section.AddTable();

                    ArrayList namearray = new ArrayList();
                    ArrayList Fatherarray = new ArrayList();
                    ArrayList montharray = new ArrayList();
                    ArrayList arrearsarray = new ArrayList();

                    for (int i = 0; i <= DefaultArray.ToArray().Length - 1; i++)
                    {
                        int ids = (Convert.ToInt32(DefaultArray[i]));
                        var data = db.StudentDatas.Where(c => c.ID == ids).FirstOrDefault();
                        namearray.Add(data.StudentName.ToString());
                        Fatherarray.Add(data.FatherName.ToString());

                        var list = db.StudentFees.Where(c => c.ID == data.ID).FirstOrDefault();
                        int month = TutionFee((Convert.ToInt32(DefaultArray[i]))) + list.TransportFee + list.ExamFee + list.OthersFee;

                        montharray.Add(month.ToString());

                        arrearsarray.Add(list.Arrears.ToString());
                    }

                    table.ResetCells(DefaultArray.ToArray().Length + 1, 4);

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
                    textRange = wParagraph.AppendText("This Month");
                    textRange.CharacterFormat.FontName = "Century Gothic";
                    textRange.CharacterFormat.FontSize = 9;
                    textRange.CharacterFormat.Bold = true;

                    //Header 4
                    wParagraph = table[0, 3].AddParagraph();
                    wParagraph.ParagraphFormat.AfterSpacing = 2f;
                    wParagraph.ParagraphFormat.BeforeSpacing = 2f;
                    wParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    textRange = wParagraph.AppendText("Arrears");
                    textRange.CharacterFormat.FontName = "Century Gothic";
                    textRange.CharacterFormat.FontSize = 9;
                    textRange.CharacterFormat.Bold = true;


                    for (int i = 0; i <= DefaultArray.ToArray().Length - 1; i++)
                    {

                        int index = i + 1;
                        IWParagraph Paragraph = table[index, 0].AddParagraph();
                        Paragraph.ParagraphFormat.AfterSpacing = 2f;
                        Paragraph.ParagraphFormat.BeforeSpacing = 2f;
                        Paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Left;
                        textRange = Paragraph.AppendText(namearray[i].ToString());
                        textRange.CharacterFormat.FontName = "Century Gothic";
                        textRange.CharacterFormat.FontSize = 9;
                        textRange.CharacterFormat.Bold = false;

                        Paragraph = table[index, 1].AddParagraph();
                        Paragraph.ParagraphFormat.AfterSpacing = 2f;
                        Paragraph.ParagraphFormat.BeforeSpacing = 2f;
                        Paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Left;
                        textRange = Paragraph.AppendText(Fatherarray[i].ToString());
                        textRange.CharacterFormat.FontName = "Century Gothic";
                        textRange.CharacterFormat.FontSize = 9;
                        textRange.CharacterFormat.Bold = false;

                        Paragraph = table[index, 2].AddParagraph();
                        Paragraph.ParagraphFormat.AfterSpacing = 2f;
                        Paragraph.ParagraphFormat.BeforeSpacing = 2f;
                        Paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                        textRange = Paragraph.AppendText("Rs. " + montharray[i].ToString());
                        textRange.CharacterFormat.FontName = "Century Gothic";
                        textRange.CharacterFormat.FontSize = 9;
                        textRange.CharacterFormat.Bold = false;

                        Paragraph = table[index, 3].AddParagraph();
                        Paragraph.ParagraphFormat.AfterSpacing = 2f;
                        Paragraph.ParagraphFormat.BeforeSpacing = 2f;
                        Paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                        textRange = Paragraph.AppendText("Rs. " + arrearsarray[i].ToString());
                        textRange.CharacterFormat.FontName = "Century Gothic";
                        textRange.CharacterFormat.FontSize = 9;
                        textRange.CharacterFormat.Bold = false;

                    }


                    //Saves the document in the given name and format

                    string savepath = "DefaulterList-" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".docx";
                    document.Save(savepath, FormatType.Docx);

                    //Releases the resources occupied by WordDocument instance

                    document.Close();

                    PrintWord(System.Windows.Forms.Application.StartupPath + @"\" + savepath, "Microsoft Print to PDF");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error - Student Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            labelstd.Text = "Nil";
            labelstddef.Text = "Nil";
            labelstdsub.Text = "Nil";
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
    }
}