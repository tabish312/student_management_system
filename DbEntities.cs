using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management_System
{
    class DbEntities : DbContext
    {
        public DbEntities() :
            base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = Application.StartupPath + @"\Database\database-2019.db", ForeignKeys = true }.ConnectionString
            }, true)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<StudentData> StudentDatas { get; set; }

        public DbSet<StudentProfile> StudentProfiles { get; set; }

        public DbSet<Random> Randoms { get; set; }

        public DbSet<StudentFee> StudentFees { get; set; }
    }
}
