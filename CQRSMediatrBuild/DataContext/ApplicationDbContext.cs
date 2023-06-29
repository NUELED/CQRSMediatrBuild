using Microsoft.EntityFrameworkCore;

namespace CQRSMediatrBuild.DataContext
{
    public class ApplicationDbContext : DbContext
    {



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }   


        public DbSet<Product> Products { get; set;}


    }
}
