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
    public partial class ViewStudent : MetroForm
    {
        DbEntities db = new DbEntities();
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {

            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();
            this.CaptionFont = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelcopyright.Text = "© Copyright - Student Management Sytem | Powered by TabiSoft Solutions";
            labelcopyright.Font = new Font(EmbedFont.private_fonts.Families[0], 8);


            var data = db.StudentDatas.Where(c => c.ID == SearchStudent.STUDENT_ID).FirstOrDefault();
            this.Text = data.StudentName.ToString();

            labelname.Text = data.StudentName;
            labelfname.Text = data.FatherName;
            labelmname.Text = data.MotherName;
            labeldob.Text = data.DateOfBirth;
            labelpob.Text = data.PlaceOfBirth;
            labelnic.Text = data.NIC;
            labelgender.Text = data.Gender;
            labelreligion.Text = data.Religion;
            labelcontact.Text = data.Contact;
            labeladdress.Text = data.Address;

            labelregno.Text = data.RegNo;
            labelclass.Text = data.Class;
            labelsec.Text = data.Section;
            labeladmitdate.Text = data.AdmitDate;
            labelsesion.Text = data.Session;



            pictureBoxProfile.Image = ByteToImage(data.ID);



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