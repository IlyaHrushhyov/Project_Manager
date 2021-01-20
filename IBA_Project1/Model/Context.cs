using IBA_Project1.Model.Entities;
using System.Data.Entity;

namespace IBA_Project1
{
    public class Context : DbContext
    {
        public Context()
            :base("DbConnection")
        { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
    }
}
