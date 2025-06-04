using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AquaMind.API.Data
{
    /// <summary>
    /// Factory para criar instâncias do AppDbContext durante o design-time
    /// Usado principalmente para Entity Framework Migrations
    /// </summary>
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Configuração para desenvolvimento com SQLite
            var connectionString = "Data Source=aquamind_dev.db";
            
            optionsBuilder.UseSqlite(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
