using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Exercise6.Misc
{
    class Database
    {
        public class DbConnection : DbContext
        {
            public DbSet<Student> Student { get; set; }
            public DbSet<Course> Course { get; set; }
            public DbSet<CoursesWithStudents> CoursesWithStudents { get; set; }
            
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = @"Donau.hiof.no",
                    InitialCatalog = "hermannl",
                    UserID = "hermannl",
                    Password = "XDkgeb6n"
                };
               
                optionsBuilder.UseSqlServer(builder.ConnectionString.ToString());
            }
        }
    }
}
