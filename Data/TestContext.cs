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

    }
}
