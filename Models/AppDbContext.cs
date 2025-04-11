using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BookManager.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserBookStatus> UserBookStatuses { get; set; }
        public DbSet<CurrencyRateEntity> CurrencyRates { get; set; }

    }
}
