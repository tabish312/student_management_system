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
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Text.RegularExpressions;
using System.Collections;

namespace Student_Management_System
{
    public partial class AddStudent : MetroForm
    {
        
        Bitmap _profileimage_male = Student_Management_System.Properties.Resources.profile_male;
        Bitmap _profileimage_female = Student_Management_System.Properties.Resources.profile_female;
        byte[] bimage;
        DbEntities db = new DbEntities();
        BackgroundWorker bw;
        Loading main;
        StudentData std;
        StudentProfile stdprf;
        StudentFee stdfee;
        bool error;
        public AddStudent()
        {
            InitializeComponent();
            this.Icon = global::Student_Management_System.Properties.Resources.icon;
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();
            this.CaptionFont = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelcopyright.Text = "© Copyright - Student Management Sytem | Powered by TabiSoft Solutions";
            labelcopyright.Font = new Font(EmbedFont.private_fonts.Families[0], 8);
            labelresult.Font = new Font(EmbedFont.private_fonts.Families[2], 11);

            var cls = db.Randoms.Where(c => c.ID == 26).FirstOrDefault();
            var clasarray = cls.Text.Split(',');

            var sec = db.Randoms.Where(c => c.ID == 27).FirstOrDefault();
            var secarray = sec.Text.Split(',');


            string[] gender = { "Male", "Female" };
            ComboBoxGender.DataSource = gender;
            comboboxclass.DataSource = clasarray;
            comboboxsection.DataSource = secarray;
            Admitdatepicker.Value = DateTime.Now;

            

        }

        private void btnupload_Click(object sender, EventArgs e)
        {


            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpeg*.png;*.jpg)|*.jpeg;*.png;*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                labelfile.Text = Path.GetFileName(open.FileName);
            }

            string image = open.FileName;
            Bitmap bmp = new Bitmap(image);
            FileStream fs = new FileStream(image, FileMode.Open, FileAccess.Read);
            bimage = new byte[fs.Length];
            fs.Read(bimage, 0, Convert.ToInt32(fs.Length));
            fs.Close();

            pictureBoxProfile.Image = new Bitmap(bmp);

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;


            if (txtstdname.Text != null && txtstdname.Text != "" && txtathername.Text != null && txtathername.Text != "" && txtregno.Text != null && txtregno.Text != "" &&
                   txtmothername.Text != null && txtmothername.Text != "" && DateofBirthPicker.Text != null && DateofBirthPicker.Text != "" && txtaddress.Text != null && txtaddress.Text != "" &&
                   txtplaceofbirth.Text != null && txtplaceofbirth.Text != "" && txtcnic.Text != null && txtcnic.Text != "" &&
                   ComboBoxGender.Text != null && ComboBoxGender.Text != "" && txtreligion.Text != null && txtreligion.Text != "" &&
                   txtcontact.Text != null && txtcontact.Text != "" && comboboxclass.Text != null && comboboxclass.Text != "" &&
                   txtsession.Text != null && txtsession.Text != "" &&
                   comboboxsection.Text != null && comboboxsection.Text != "" && Admitdatepicker.Text != null && Admitdatepicker.Text != "")
            {


                byte[] a = ImageToByte(_profileimage_male);
                byte[] b = ImageToByte(_profileimage_female);
                byte[] c = ImageToByte((Bitmap)pictureBoxProfile.Image);


                DateTime dob = Convert.ToDateTime(DateofBirthPicker.Value);
                DateTime admit = Convert.ToDateTime(Admitdatepicker.Value);

                string name = txtstdname.Text;
                name = Regex.Replace(name, @"(^\w)|(\s\w)", m => m.Value.ToUpper());

                string fathername = txtathername.Text;
                fathername = Regex.Replace(fathername, @"(^\w)|(\s\w)", m => m.Value.ToUpper());

                string mothername = txtmothername.Text;
                mothername = Regex.Replace(mothername, @"(^\w)|(\s\w)", m => m.Value.ToUpper());

                string PlaceOfBirth = txtplaceofbirth.Text;
                PlaceOfBirth = Regex.Replace(PlaceOfBirth, @"(^\w)|(\s\w)", m => m.Value.ToUpper());

                var data = db.Randoms.Where(x => x.ID == 26).FirstOrDefault();
                ArrayList arrayList = new ArrayList();
                arrayList.AddRange(data.Text.Split(','));

                int index = 0;
                for (int i = 0; i <= arrayList.ToArray().Length - 1; i++)
                {
                    if (comboboxclass.Text == arrayList[i].ToString())
                    {
                        index = i;
                        break;
                    }
                }
                var othersfee = db.Randoms.Where(x => x.ID == 28).FirstOrDefault();
                var latefee = db.Randoms.Where(x => x.ID == 29).FirstOrDefault();
                var fee = db.Randoms.Where(x => x.ID == 32).FirstOrDefault();
                var feearray = fee.Text.Split(';');

                var feearray1 = feearray[index].ToString().Split(',');
                string fees = feearray1[0].ToString() + "," + feearray1[0].ToString() + "," + feearray1[0].ToString() + "," + feearray1[0].ToString() + "," + feearray1[0].ToString() + "," + feearray1[0].ToString() + "," + feearray1[0].ToString() + "," + feearray1[0].ToString() + "," + feearray1[0].ToString() + "," + feearray1[0].ToString() + "," + feearray1[0].ToString() + "," + feearray1[0].ToString();


                try
                {
                    std = new StudentData()
                    {
                        StudentName = name,
                        FatherName = fathername,
                        RegNo = txtregno.Text,
                        MotherName = mothername,
                        DateOfBirth = dob.ToString("dd/MM/yyyy"),
                        PlaceOfBirth = PlaceOfBirth,
                        Address = txtaddress.Text,
                        NIC = txtcnic.Text,
                        Gender = ComboBoxGender.Text,
                        Religion = txtreligion.Text,
                        Contact = txtcontact.Text,
                        Class = comboboxclass.Text,
                        Section = comboboxsection.Text,
                        AdmitDate = admit.ToString("dd/MM/yyyy"),
                        Session = txtsession.Text,
                        Fees = fees,
                        Arrears = 0,
                        FeeSubmittedDate = "null"
                    };

                    stdprf = new StudentProfile();


                    if ((a.Length == c.Length || b.Length == c.Length) && MessageBox.Show("Are you sure you want to add student data without profile pic?", "Waring - Student Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        if (a.Length == c.Length)
                        {
                            stdprf.Profile = a;
                        }
                        if (b.Length == c.Length)
                        {
                            stdprf.Profile = b;
                        }
                    }
                    else
                    {
                        stdprf.Profile = bimage;
                    }

                    stdfee = new StudentFee()
                    {
                        TransportFee = 0,
                        ExamFee = Convert.ToInt32(feearray1[1].ToString()),
                        OthersFee = Convert.ToInt32(othersfee.Text),
                        LateFee = Convert.ToInt32(latefee.Text),
                        Arrears = 0,
                        VoucherCharges = 0,
                        AmountSubmit = 0,
                        Submitted = false,
                        SubmittedDate = "null"
                    };


                    Bitmap bitmap = Student_Management_System.Properties.Resources.loading_f;
                    main = new Loading("Saving...", "#EE3322", bitmap);
                    main.Show();
                    if (!bw.IsBusy)
                    {
                        bw.RunWorkerAsync();
                    }

                }
                catch (Exception ex)
                {
                    error = true;
                    MessageBox.Show(ex.Message.ToString(), "Something Went wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                labelresult.Text = "*All fields are mandatory!";
                labelresult.ForeColor = Color.Red;
                labelresult.Visible = true;
            }

            


        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            main.Hide();
            if (!error)
            {
                MessageBox.Show("You have successfully added a new record named as: " + txtstdname.Text, "New record added - Student Management System", MessageBoxButtons.OK, MessageBoxIcon.None);
                btnreset_Click(sender, e);
            }

        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                db.StudentDatas.Add(std);
                db.StudentProfiles.Add(stdprf);
                db.StudentFees.Add(stdfee);
                db.SaveChanges();
                error = false;
            }
            catch (Exception ex)
            {
                error = true;
                MessageBox.Show(ex.Message.ToString(), "Something Went wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static byte[] BitmapToBytes(Bitmap Bitmap)
        {
            MemoryStream ms = null;
            try
            {
                ms = new MemoryStream();
                Bitmap.Save(ms, Bitmap.RawFormat);
                byte[] byteImage = new Byte[ms.Length];
                byteImage = ms.ToArray();
                return byteImage;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            finally
            {
                ms.Close();
            }
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void ComboBoxGender_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ComboBoxGender.Text == "Male")
            {
                pictureBoxProfile.Image = Student_Management_System.Properties.Resources.profile_male;
                bimage = ImageToByte(_profileimage_male);
            }
            else if (ComboBoxGender.Text == "Female")
            {
                pictureBoxProfile.Image = Student_Management_System.Properties.Resources.profile_female;
                bimage = ImageToByte(_profileimage_female);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtstdname.Text = "";
            txtathername.Text = "";
            txtregno.Text = "";
            txtmothername.Text = "";
            DateofBirthPicker.Text = "";
            txtaddress.Text = "";
            txtplaceofbirth.Text = "";
            txtcnic.Text = "";
            ComboBoxGender.SelectedValue = "";
            txtreligion.Text = "";
            txtcontact.Text = "";
            comboboxclass.SelectedValue = "";
            comboboxsection.SelectedValue = "";
            comboboxclass.SelectedValue = "";
            Admitdatepicker.Text = "";
            labelfile.Text = "No File Chosen: ";
            pictureBoxProfile.Image = new Bitmap(_profileimage_male);
            labelresult.Visible = false;
        }

        private void AddStudent_Activated(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
