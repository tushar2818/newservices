//http://www.entityframeworktutorial.net/code-first/foreignkey-dataannotations-attribute-in-code-first.aspx
//https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/existing-db
//to update database
//https://stackoverflow.com/questions/50767086/class-library-wth-ef-core-2-1-no-executable-found-matching-command-dotnet-ef
//https://stackoverflow.com/questions/44074992/how-to-update-db-using-code-first-net-core

using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityService.Models;

namespace IdentityService.DATA
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    } 
}
