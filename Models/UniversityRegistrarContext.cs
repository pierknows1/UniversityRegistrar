using Microsoft.EntityFrameworkCore;

namespace UniversityRegistrar.Models
{
    public class UniversityRegistrarContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }
        public UniversityRegistrarContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.CourseId, sc.StudentId });
    }
    }
}