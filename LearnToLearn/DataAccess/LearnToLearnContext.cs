using LearnToLearn.Models;
using System.Data.Entity;

namespace LearnToLearn.DataAccess
{
    public class LearnToLearnContext : DbContext
    {
        public LearnToLearnContext() : base("LearnToLearnDb")
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }
    }
}