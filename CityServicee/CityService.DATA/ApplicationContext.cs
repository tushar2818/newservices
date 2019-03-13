//http://www.entityframeworktutorial.net/code-first/foreignkey-dataannotations-attribute-in-code-first.aspx
//https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/existing-db
//to update database
//https://stackoverflow.com/questions/50767086/class-library-wth-ef-core-2-1-no-executable-found-matching-command-dotnet-ef
//https://stackoverflow.com/questions/44074992/how-to-update-db-using-code-first-net-core

using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CityService.DATA
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

            //modelBuilder.Entity<BusTimeTable>()
            //.HasOne<BusStandMaster>(s => s.BusStandMaster)
            //.WithMany()
            //.HasForeignKey(s => s.BusStandId).OnDelete(DeleteBehavior.Cascade); ;  
             
        } 

        public DbSet<RawDataCity> RawDataCity { get; set; }
        public DbSet<Citys> Citys { get; set; }

    }  
}
