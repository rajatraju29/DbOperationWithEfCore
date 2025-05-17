using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DbOperationsForEfCore.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { id=1,Title="INR",Description="INDIAN INR"},
                new Currency() { id=2,Title="Dollar",Description= "Dollar" },
                new Currency() { id=3,Title="Euro",Description= "Euro" },
                new Currency() { id=4,Title="Dinar",Description= "Dinar" }
                );
            modelBuilder.Entity<Language>().HasData(
               new Currency() { id = 1, Title = "Hindi", Description = "Hindi" },
               new Currency() { id = 2, Title = "Tamil", Description = "Tamil" },
               new Currency() { id = 3, Title = "Punjabi", Description = "Punjabi" },
               new Currency() { id = 4, Title = "Urdu", Description = "Urdu" }
               );
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
