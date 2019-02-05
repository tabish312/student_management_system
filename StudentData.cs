using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Linq.Mapping;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    [Table(Name = "UserLogin")]
    class StudentData
    {
        [Display(Name ="ID")]
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ID { get; set; }

        [Display(Name = "Studnet Name")]
        [Column(Name = "StudentName", DbType = "NVARCHAR")]
        public string StudentName { get; set; }
        
        [Display(Name = "Registration No.")]
        [Column(Name = "RegNo", DbType = "NVARCHAR")]
        public string RegNo { get; set; }

        [Display(Name = "Father's Name")]
        [Column(Name = "FatherName", DbType = "NVARCHAR")]
        public string FatherName { get; set; }

        [Display(Name = "Mother's Name")]
        [Column(Name = "MotherName", DbType = "NVARCHAR")]
        public string MotherName { get; set; }

        [Display(Name = "Date of Birth")]
        [Column(Name = "DateOfBirth", DbType = "NVARCHAR")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Place of Birth")]
        [Column(Name = "PlaceOfBirth", DbType = "NVARCHAR")]
        public string PlaceOfBirth { get; set; }


        [Display(Name = "B.Form")]
        [Column(Name = "NIC", DbType = "NVARCHAR")]
        public string NIC { get; set; }

        [Display(Name = "Gender")]
        [Column(Name = "Gender", DbType = "NVARCHAR")]
        public string Gender { get; set; }

        [Display(Name = "Address")]
        [Column(Name = "Address", DbType = "NVARCHAR")]
        public string Address { get; set; }

        [Display(Name = "Religion")]
        [Column(Name = "Religion", DbType = "NVARCHAR")]
        public string Religion { get; set; }

        [Display(Name = "Contact")]
        [Column(Name = "Contact", DbType = "NVARCHAR")]
        public string Contact { get; set; }

        [Display(Name = "Class")]
        [Column(Name = "Class", DbType = "NVARCHAR")]
        public string Class { get; set; }

        [Display(Name = "Section")]
        [Column(Name = "Section", DbType = "NVARCHAR")]
        public string Section { get; set; }

        [Display(Name = "Admitted Date")]
        [Column(Name = "AdmitDate", DbType = "NVARCHAR")]
        public string AdmitDate { get; set; }

        [Display(Name = "Session")]
        [Column(Name = "Session", DbType = "NVARCHAR")]
        public string Session { get; set; }

        [Display(Name = "Fees")]
        [Column(Name = "Fees", DbType = "NVARCHAR")]
        public string Fees { get; set; }

        [Display(Name = "Arrears")]
        [Column(Name = "Arrears", DbType = "INTEGER")]
        public int Arrears { get; set; }

        [Display(Name = "Fee Submitted Date")]
        [Column(Name = "FeeSubmittedDate", DbType = "NVARCHAR")]
        public string FeeSubmittedDate { get; set; }
    }
}
