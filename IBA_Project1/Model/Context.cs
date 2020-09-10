using System.Data.Entity;

namespace IBA_Project1
{
    class Context : DbContext
    {
        public Context()
            :base("DbConnection")
        { }

        public DbSet<Project> Projects { get; set; }
    }
}
