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
    class UserLogin
    {
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ID { get; set; }

        [Column(Name = "UserName", DbType = "NVARCHAR")]
        public string UserName { get; set; }

        [Column(Name = "Password", DbType = "NVARCHAR")]
        public string Password { get; set; }
    }
}
