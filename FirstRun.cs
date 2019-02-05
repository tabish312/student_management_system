using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;

namespace Student_Management_System
{
    public partial class FirstRun : MetroForm
    {
        
        public FirstRun()
        {
            InitializeComponent();
        }

        private void FirstRun_Load(object sender, EventArgs e)
        {
            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();
            this.CaptionFont = new Font(EmbedFont.private_fonts.Families[2], 9);
            /*/
            labelw.Font = new Font(EmbedFont.private_fonts.Families[0], 32);
            labelwelcom.Font = new Font(EmbedFont.private_fonts.Families[0], 24);/*/
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
