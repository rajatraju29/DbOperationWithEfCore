using Microsoft.EntityFrameworkCore;

namespace DbOperationsForEfCore.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
    }
}
