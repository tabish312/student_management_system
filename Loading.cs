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
    public partial class Loading : Form
    {
        public Loading(string name,string color,Bitmap pictureBox)
        {
            InitializeComponent();
            this.Icon = global::Student_Management_System.Properties.Resources.icon;
            this.ShowIcon = true;
            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();
            this.labelprinting.Font = new Font(EmbedFont.private_fonts.Families[2], 13);
            this.labelprinting.Text = name;
            this.Text = name;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(color);
            this.pictureBox1.Image = pictureBox;
            this.labelprinting.ForeColor = ColorTranslator.FromHtml(color);
        }
    }
}
