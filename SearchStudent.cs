using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Design;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Styles;
using Syncfusion.WinForms.GridCommon.ScrollAxis;

namespace Student_Management_System
{
    public partial class SearchStudent : MetroForm
    {
        DbEntities db = new DbEntities();
        public static int STUDENT_ID = 0;

        public SearchStudent()
        {
            InitializeComponent();
            this.Icon = global::Student_Management_System.Properties.Resources.icon;
            this.ShowIcon = true;
        }

        private void SearchStudent_Load(object sender, EventArgs e)
        {
            EmbedFont.LoadComfortaaFont();
            EmbedFont.LoadMicrossFont();
            EmbedFont.LoadRalewayFont();
            this.CaptionFont = new Font(EmbedFont.private_fonts.Families[2], 9);
            groupBoxstd.Font = new Font(EmbedFont.private_fonts.Families[0], 9);
            labelsearchid.Font = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelsearchreg.Font = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelsearchname.Font = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelfilter.Font = new Font(EmbedFont.private_fonts.Families[2], 9);
            labelyear.Font = new Font(EmbedFont.private_fonts.Families[2], 9);
            
            var cls = db.Randoms.Where(c => c.ID == 26).FirstOrDefault();
            var clasarray = cls.Text.Split(',');

            comboboxclass.DataSource = clasarray;

            var b = db.StudentDatas.Select(c => new { c.ID, c.RegNo, c.StudentName, c.FatherName, c.DateOfBirth, c.Gender, c.NIC, c.Religion, c.Contact, c.Class, c.Section, c.Address, c.AdmitDate }).ToList();

            sfDataPager.DataSource = b;
            sfDataPager.PageSize = 20;
            sfDataGrid.DataSource = sfDataPager.PagedSource;
            GridNames();

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            name = Regex.Replace(name, @"(^\w)|(\s\w)", m => m.Value.ToUpper());

            if ((txtid.Text != "" && txtid.Text != null) ||
                     (txtreg.Text != null && txtreg.Text != "") ||
                     (txtname.Text != null && txtname.Text != "") ||
                     (comboboxclass.SelectedValue != null && comboboxclass.Text != null && comboboxclass.Text != "") ||
                     (txtyear.Text != null && txtyear.Text != ""))
            {

                #region Search By Id
                if (txtid.Text != "" && txtreg.Text == "" && txtname.Text == "" && (comboboxclass.Text == "" || comboboxclass.Text == "Select class") && txtyear.Text == "")
                {
                    try
                    {
                        int id = Convert.ToInt32(txtid.Text);
                        var sea = db.StudentDatas.Where(c => c.ID == id).Select(c => new { c.ID, c.RegNo, c.StudentName, c.FatherName, c.DateOfBirth, c.Gender, c.NIC, c.Religion, c.Contact, c.Class, c.Section, c.Address, c.AdmitDate }).ToList();
                        if (sea != null && sea.Any())
                        {
                            sfDataPager.DataSource = sea;
                            sfDataPager.PageSize = 20;
                            sfDataGrid.DataSource = sfDataPager.PagedSource;
                        }
                        else
                        {
                            MessageBox.Show("No Record Found!", "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                #endregion

                #region Search by Registration No
                if (txtid.Text == "" && txtreg.Text != "" && txtname.Text == "" && (comboboxclass.Text == "" || comboboxclass.Text == "Select class") && txtyear.Text == "")
                {
                    try
                    {
                        var sea = db.StudentDatas.Where(c => c.RegNo == txtreg.Text).Select(c => new { c.ID, c.RegNo, c.StudentName, c.FatherName, c.DateOfBirth, c.Gender, c.NIC, c.Religion, c.Contact, c.Class, c.Section, c.Address, c.AdmitDate }).ToList();
                        if (sea != null && sea.Any())
                        {
                            sfDataPager.DataSource = sea;
                            sfDataPager.PageSize = 20;
                            sfDataGrid.DataSource = sfDataPager.PagedSource;

                        }
                        else
                        {
                            MessageBox.Show("No Record Found!", "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                #endregion

                #region Search by Name
                if (txtid.Text == "" && txtreg.Text == "" && txtname.Text != "" && (comboboxclass.Text == "" || comboboxclass.Text == "Select class") && txtyear.Text == "")
                {
                    try
                    {
                        var sea = db.StudentDatas.Where(c => c.StudentName == name).Select(c => new { c.ID, c.RegNo, c.StudentName, c.FatherName, c.DateOfBirth, c.Gender, c.NIC, c.Religion, c.Contact, c.Class, c.Section, c.Address, c.AdmitDate }).ToList();
                        if (sea != null && sea.Any())
                        {
                            sfDataPager.DataSource = sea;
                            sfDataPager.PageSize = 20;
                            sfDataGrid.DataSource = sfDataPager.PagedSource;
                        }
                        else
                        {
                            MessageBox.Show("No Record Found!", "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                #endregion

                #region Search by Class
                if (txtid.Text == "" && txtreg.Text == "" && txtname.Text == "" && (comboboxclass.Text != "") && txtyear.Text == "")
                {
                    try
                    {
                        var sea = db.StudentDatas.Where(c => c.Class == comboboxclass.SelectedValue.ToString()).Select(c => new { c.ID, c.RegNo, c.StudentName, c.FatherName, c.DateOfBirth, c.Gender, c.NIC, c.Religion, c.Contact, c.Class, c.Section, c.Address, c.AdmitDate }).ToList();
                        if (sea != null && sea.Any())
                        {
                            sfDataPager.DataSource = sea;
                            sfDataPager.PageSize = 20;
                            sfDataGrid.DataSource = sfDataPager.PagedSource;
                        }
                        else
                        {
                            MessageBox.Show("No Record Found!", "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                #endregion

                #region Search by Year
                if (txtid.Text == "" && txtreg.Text == "" && txtname.Text == "" && (comboboxclass.Text == "" || comboboxclass.Text == "Select class") && txtyear.Text != "")
                {
                    try
                    {
                        var sea = db.StudentDatas.Where(c => c.Session == txtyear.Text).Select(c => new { c.ID, c.RegNo, c.StudentName, c.FatherName, c.DateOfBirth, c.Gender, c.NIC, c.Religion, c.Contact, c.Class, c.Section, c.Address, c.AdmitDate }).ToList();
                        if (sea != null && sea.Any())
                        {
                            sfDataPager.DataSource = sea;
                            sfDataPager.PageSize = 20;
                            sfDataGrid.DataSource = sfDataPager.PagedSource;

                        }
                        else
                        {
                            MessageBox.Show("No Record Found!", "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                #endregion

                #region Search By Id And Reg No
                if (txtid.Text != "" && txtreg.Text != "" && txtname.Text == "" && (comboboxclass.Text == "" || comboboxclass.Text == "Select class") && txtyear.Text == "")
                {
                    try
                    {
                        int id = Convert.ToInt32(txtid.Text);
                        var sea = db.StudentDatas.Where(c => c.ID == id && c.RegNo == txtreg.Text).Select(c => new { c.ID, c.RegNo, c.StudentName, c.FatherName, c.DateOfBirth, c.Gender, c.NIC, c.Religion, c.Contact, c.Class, c.Section, c.Address, c.AdmitDate }).ToList();
                        if (sea != null && sea.Any())
                        {
                            sfDataPager.DataSource = sea;
                            sfDataPager.PageSize = 20;
                            sfDataGrid.DataSource = sfDataPager.PagedSource;
                        }
                        else
                        {
                            MessageBox.Show("No Record Found!", "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                #endregion

                #region Search By Id And Name
                if (txtid.Text != "" && txtreg.Text == "" && txtname.Text != "" && (comboboxclass.Text == "" || comboboxclass.Text == "Select class") && txtyear.Text == "")
                {
                    try
                    {
                        int id = Convert.ToInt32(txtid.Text);
                        var sea = db.StudentDatas.Where(c => c.ID == id && c.StudentName == name).Select(c => new { c.ID, c.RegNo, c.StudentName, c.FatherName, c.DateOfBirth, c.Gender, c.NIC, c.Religion, c.Contact, c.Class, c.Section, c.Address, c.AdmitDate }).ToList();
                        if (sea != null && sea.Any())
                        {
                            sfDataPager.DataSource = sea;
                            sfDataPager.PageSize = 20;
                            sfDataGrid.DataSource = sfDataPager.PagedSource;
                        }
                        else
                        {
                            MessageBox.Show("No Record Found!", "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                #endregion



                #region Search By Id And Class
                if (txtid.Text != "" && txtreg.Text == "" && txtname.Text == "" && (comboboxclass.Text != "Select class") && txtyear.Text == "")
                {
                    try
                    {
                        int id = Convert.ToInt32(txtid.Text);
                        var sea = db.StudentDatas.Where(c => c.ID == id && c.Class == comboboxclass.Text).Select(c => new { c.ID, c.RegNo, c.StudentName, c.FatherName, c.DateOfBirth, c.Gender, c.NIC, c.Religion, c.Contact, c.Class, c.Section, c.Address, c.AdmitDate }).ToList();
                        if (sea != null && sea.Any())
                        {
                            sfDataPager.DataSource = sea;
                            sfDataPager.PageSize = 20;
                            sfDataGrid.DataSource = sfDataPager.PagedSource;
                        }
                        else
                        {
                            MessageBox.Show("No Record Found!", "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                #endregion


                #region Search By Id And Year
                if (txtid.Text != "" && txtreg.Text == "" && txtname.Text == "" && (comboboxclass.Text == "" || comboboxclass.Text == "Select class") && txtyear.Text != "")
                {
                    try
                    {
                        int id = Convert.ToInt32(txtid.Text);
                        var sea = db.StudentDatas.Where(c => c.ID == id && c.Session == txtyear.Text).Select(c => new { c.ID, c.RegNo, c.StudentName, c.FatherName, c.DateOfBirth, c.Gender, c.NIC, c.Religion, c.Contact, c.Class, c.Section, c.Address, c.AdmitDate }).ToList();
                        if (sea != null && sea.Any())
                        {
                            sfDataPager.DataSource = sea;
                            sfDataPager.PageSize = 20;
                            sfDataGrid.DataSource = sfDataPager.PagedSource;
                        }
                        else
                        {
                            MessageBox.Show("No Record Found!", "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                #endregion


                #region Search By Reg No And Name
                if (txtid.Text == "" && txtreg.Text != "" && txtname.Text != "" && (comboboxclass.Text == "" || comboboxclass.Text == "Select class") && txtyear.Text == "")
                {
                    try
                    {
                        var sea = db.StudentDatas.Where(c => c.RegNo == txtreg.Text && c.StudentName == name).Select(c => new { c.ID, c.RegNo, c.StudentName, c.FatherName, c.DateOfBirth, c.Gender, c.NIC, c.Religion, c.Contact, c.Class, c.Section, c.Address, c.AdmitDate }).ToList();
                        if (sea != null && sea.Any())
                        {
                            sfDataPager.DataSource = sea;
                            sfDataPager.PageSize = 20;
                            sfDataGrid.DataSource = sfDataPager.PagedSource;
                        }
                        else
                        {
                            MessageBox.Show("No Record Found!", "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                #endregion 

                #region Search By Reg No And Class
                if (txtid.Text == "" && txtreg.Text != "" && txtname.Text == "" && (comboboxclass.Text != "Select class") && txtyear.Text == "")
                {
                    try
                    {
                        var sea = db.StudentDatas.Where(c => c.RegNo == txtreg.Text && c.Class == comboboxclass.Text).Select(c => new { c.ID, c.RegNo, c.StudentName, c.FatherName, c.DateOfBirth, c.Gender, c.NIC, c.Religion, c.Contact, c.Class, c.Section, c.Address, c.AdmitDate }).ToList();
                        if (sea != null && sea.Any())
                        {
                            sfDataPager.DataSource = sea;
                            sfDataPager.PageSize = 20;
                            sfDataGrid.DataSource = sfDataPager.PagedSource;
                        }
                        else
                        {
                            MessageBox.Show("No Record Found!", "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                #endregion

                #region Search By Reg No And Year
                if (txtid.Text == "" && txtreg.Text != "" && txtname.Text == "" && (comboboxclass.Text == "" || comboboxclass.Text == "Select class") && txtyear.Text != "")
                {
                    try
                    {
                        var sea = db.StudentDatas.Where(c => c.RegNo == txtreg.Text && c.Session == txtyear.Text).Select(c => new { c.ID, c.RegNo, c.StudentName, c.FatherName, c.DateOfBirth, c.Gender, c.NIC, c.Religion, c.Contact, c.Class, c.Section, c.Address, c.AdmitDate }).ToList();
                        if (sea != null && sea.Any())
                        {
                            sfDataPager.DataSource = sea;
                            sfDataPager.PageSize = 20;
                            sfDataGrid.DataSource = sfDataPager.PagedSource;
                        }
                        else
                        {
                            MessageBox.Show("No Record Found!", "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                #endregion

                #region Search By Name And Class
                if (txtid.Text == "" && txtreg.Text == "" && txtname.Text != "" && (comboboxclass.Text != "Select class") && txtyear.Text == "")
                {
                    try
                    {
                        var sea = db.StudentDatas.Where(c => c.StudentName == name && c.Class == comboboxclass.Text).Select(c => new { c.ID, c.RegNo, c.StudentName, c.FatherName, c.DateOfBirth, c.Gender, c.NIC, c.Religion, c.Contact, c.Class, c.Section, c.Address, c.AdmitDate }).ToList();
                        if (sea != null && sea.Any())
                        {
                            sfDataPager.DataSource = sea;
                            sfDataPager.PageSize = 20;
                            sfDataGrid.DataSource = sfDataPager.PagedSource;
                        }
                        else
                        {
                            MessageBox.Show("No Record Found!", "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                #endregion

                #region Search By Name And Year
                if (txtid.Text == "" && txtreg.Text == "" && txtname.Text != "" && (comboboxclass.Text == "Select class") && txtyear.Text != "")
                {
                    try
                    {
                        var sea = db.StudentDatas.Where(c => c.StudentName == name && c.Session == txtyear.Text).Select(c => new { c.ID, c.RegNo, c.StudentName, c.FatherName, c.DateOfBirth, c.Gender, c.NIC, c.Religion, c.Contact, c.Class, c.Section, c.Address, c.AdmitDate }).ToList();
                        if (sea != null && sea.Any())
                        {
                            sfDataPager.DataSource = sea;
                            sfDataPager.PageSize = 20;
                            sfDataGrid.DataSource = sfDataPager.PagedSource;
                        }
                        else
                        {
                            MessageBox.Show("No Record Found!", "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error - Student Management Sytem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                #endregion

            }
            else
            {
                MessageBox.Show("Enter any one field!", "Error - Student Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GridNames()
        {

            sfDataGrid.Columns[0].HeaderText = "ID";
            sfDataGrid.Columns[1].HeaderText = "Registration No.";
            sfDataGrid.Columns[2].HeaderText = "Student Name";
            sfDataGrid.Columns[3].HeaderText = "Father's Name";
            sfDataGrid.Columns[4].HeaderText = "Date of Birth";
            sfDataGrid.Columns[5].HeaderText = "Gender";
            sfDataGrid.Columns[6].HeaderText = "B.Form";
            sfDataGrid.Columns[7].HeaderText = "Religion";
            sfDataGrid.Columns[8].HeaderText = "Contact";
            sfDataGrid.Columns[9].HeaderText = "Class";
            sfDataGrid.Columns[10].HeaderText = "Section";
            sfDataGrid.Columns[11].HeaderText = "Address";
            sfDataGrid.Columns[12].HeaderText = "Admitted Date";
        }

        private void sfDataGrid_DataSourceChanged(object sender, Syncfusion.WinForms.DataGrid.Events.DataSourceChangedEventArgs e)
        {
            sfDataGrid.Columns[0].HeaderText = "ID";
            sfDataGrid.Columns[1].HeaderText = "Registration No.";
            sfDataGrid.Columns[2].HeaderText = "Student Name";
            sfDataGrid.Columns[3].HeaderText = "Father's Name";
            sfDataGrid.Columns[4].HeaderText = "Date of Birth";
            sfDataGrid.Columns[5].HeaderText = "Gender";
            sfDataGrid.Columns[6].HeaderText = "B.Form";
            sfDataGrid.Columns[7].HeaderText = "Religion";
            sfDataGrid.Columns[8].HeaderText = "Contact";
            sfDataGrid.Columns[9].HeaderText = "Class";
            sfDataGrid.Columns[10].HeaderText = "Section";
            sfDataGrid.Columns[11].HeaderText = "Address";
            sfDataGrid.Columns[12].HeaderText = "Admitted Date";
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtreg.Text = "";
            txtname.Text = "";
            comboboxclass.Text = "";
            comboboxclass.Text = "Select class";
            txtyear.Text = "";
            var b = db.StudentDatas.Select(c => new { c.ID, c.RegNo, c.StudentName, c.FatherName, c.DateOfBirth, c.Gender, c.NIC, c.Religion, c.Contact, c.Class, c.Section, c.Address, c.AdmitDate }).ToList();

            sfDataPager.DataSource = b;
            sfDataPager.PageSize = 20;
            sfDataGrid.DataSource = sfDataPager.PagedSource;
        }

        private void sfDataGrid_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            // Get the row index value        
            var rowIndex = e.DataRow.RowIndex;
            
            //Get the cell value            
            var cellValue = this.sfDataGrid.View.GetPropertyAccessProvider().GetValue(e.DataRow.RowData, "ID");
            STUDENT_ID = Convert.ToInt32(cellValue);

            ViewStudent viewStudent = new ViewStudent();
            viewStudent.ShowDialog();
        }
    }
}