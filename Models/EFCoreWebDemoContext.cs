using Microsoft.EntityFrameworkCore;
namespace Leave
{
    public class EFCoreWebDemoContext : DbContext
    {
        public EFCoreWebDemoContext(DbContextOptions<EFCoreWebDemoContext>options):base(options){

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Leavea> Leavea { get; set; }         

    }

}


  