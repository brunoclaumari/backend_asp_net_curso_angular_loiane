using APICourse.Constants;
using APICourse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICourse.Repository
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasKey(c => c.Id)
                .HasName("PK_Id_tbCourse");

            modelBuilder.Entity<Course>()
                .HasData(new List<Course>() {
                    new Course(){ Id = 1, Name = "Java", Category = UtilConstants.backend },
                    new Course(){ Id = 2, Name = "C sharp", Category = UtilConstants.backend },
                    new Course(){ Id = 3, Name = "Angular", Category = UtilConstants.frontend },
                    new Course(){ Id = 4, Name = "React JS", Category = UtilConstants.frontend },
                });


        }

    }
}
