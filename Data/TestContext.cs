using Microsoft.EntityFrameworkCore;

namespace GTest.Data
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Classroom> Classrooms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classroom>()
                .HasOne(c => c.HomeroomTeacher)
                .WithOne(t => t.Classroom)
                .HasForeignKey<Teacher>(t => t.ClassroomId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Teacher>()
                .HasOne(c => c.Classroom)
                .WithOne(t => t.HomeroomTeacher)
                .HasForeignKey<Classroom>(t => t.HomeroomTeacherId)
                .OnDelete(DeleteBehavior.SetNull);
        }

    }
}
