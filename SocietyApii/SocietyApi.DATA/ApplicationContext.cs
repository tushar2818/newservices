//http://www.entityframeworktutorial.net/code-first/foreignkey-dataannotations-attribute-in-code-first.aspx
//https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/existing-db
//to update database
//https://stackoverflow.com/questions/50767086/class-library-wth-ef-core-2-1-no-executable-found-matching-command-dotnet-ef
//https://stackoverflow.com/questions/44074992/how-to-update-db-using-code-first-net-core

using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SocietyApi.DATA
{
    public class ApplicationContext: DbContext
    { 
        public ApplicationContext(DbContextOptions opts) : base(opts)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            } 
        }

        public DbSet<CompanyMaster> CompanyMaster { get; set; }
        public DbSet<DesignationMaster> DesignationMaster { get; set; }
        public DbSet<EmployeeMaster> EmployeeMaster { get; set; }
        public DbSet<FlatMaster> FlatMaster { get; set; }
        public DbSet<FlatTypeMaster> FlatTypeMaster { get; set; }
        public DbSet<FloorMaster> FloorMaster { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployee { get; set; }
        public DbSet<ProjectMaster> ProjectMaster { get; set; }
        public DbSet<WingMaster> WingMaster { get; set; }

    }
}
