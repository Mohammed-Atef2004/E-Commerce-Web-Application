using Microsoft.EntityFrameworkCore;
using myShop.Web.Models;

namespace myShop.Web.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Category>Categories { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var config = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();
        //    var connectionString = config.GetSection("ConnectionStrings").Value;

        //    optionsBuilder.UseSqlServer(connectionString);
        //}
    }
}
