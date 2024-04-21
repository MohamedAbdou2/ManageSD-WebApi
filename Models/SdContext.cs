using Microsoft.EntityFrameworkCore;

namespace ManageSD_WebApi.Models
{
    public class SdContext:DbContext
    {
        public SdContext()
        {
            
        }

        public SdContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Course> Courses { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SDDB;Integrated Security=True;Encrypt=False;TrustServerCertificate = True");

            base.OnConfiguring(optionsBuilder);
        }



    }
}
