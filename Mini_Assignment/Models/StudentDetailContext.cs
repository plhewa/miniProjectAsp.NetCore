using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Assignment.Models
{
    public class StudentDetailContext:DbContext
    {
        public StudentDetailContext(DbContextOptions<StudentDetailContext> options):base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           


          


        }
    }
}
