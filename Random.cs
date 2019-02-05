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
    [Table(Name = "Random")]
    class Random
    {
        [Display(Name = "ID")]
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ID { get; set; }

        [Display(Name = "Key")]
        [Column(Name = "Key", DbType = "NVARCHAR")]
        public string Key { get; set; }

        [Display(Name = "Text")]
        [Column(Name = "Text", DbType = "NVARCHAR")]
        public string Text { get; set; }
    }
}
