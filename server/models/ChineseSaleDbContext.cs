using Microsoft.EntityFrameworkCore;
namespace server.models
{
    public class ChineseSaleDbContext : DbContext
    {
        public ChineseSaleDbContext(DbContextOptions<ChineseSaleDbContext> options)
            : base(options)
        {

        }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<Gift> Gift { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Lottery> Lottery { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<User> User { get; set; }

       
    }
}
