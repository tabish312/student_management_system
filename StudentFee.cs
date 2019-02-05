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
    [Table(Name = "StudentFee")]
    class StudentFee
    {
        [Display(Name = "ID")]
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ID { get; set; }

        [Display(Name = "Transport Fee")]
        [Column(Name = "TransportFee", DbType = "INTEGER")]
        public int TransportFee { get; set; }

        [Display(Name = "ExamFee")]
        [Column(Name = "ExamFee", DbType = "INTEGER")]
        public int ExamFee { get; set; }

        [Display(Name = "Others Fee")]
        [Column(Name = "OthersFee", DbType = "INTEGER")]
        public int OthersFee { get; set; }

        [Display(Name = "Late Fee")]
        [Column(Name = "LateFee", DbType = "INTEGER")]
        public int LateFee { get; set; }

        [Display(Name = "Arrears")]
        [Column(Name = "Arrears", DbType = "INTEGER")]
        public int Arrears { get; set; }

        [Display(Name = "Voucher Charges")]
        [Column(Name = "VoucherCharges", DbType = "INTEGER")]
        public int VoucherCharges { get; set; }

        [Display(Name = "AmountSubmit")]
        [Column(Name = "AmountSubmit", DbType = "INTEGER")]
        public int AmountSubmit { get; set; }

        [Display(Name = "Submitted")]
        [Column(Name = "Submitted", DbType = "BOOL")]
        public bool Submitted { get; set; }

        [Display(Name = "Submitted Date")]
        [Column(Name = "SubmittedDate", DbType = "NVARCHAR")]
        public string SubmittedDate { get; set; }

    }
}
