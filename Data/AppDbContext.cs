using AquaMind.API.Models;

namespace AquaMind.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets com nomes que coincidem com os controllers
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Propriedade> Propriedades { get; set; }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<RegistroSensor> RegistroSensors { get; set; }
        public DbSet<Bomba> Bombas { get; set; }
        public DbSet<LogAcaoBomba> LogAcaoBombas { get; set; }
        public DbSet<ConfiguracaoZona> ConfiguracaoZonas { get; set; }
        public DbSet<AlertaUmidade> AlertaUmidades { get; set; }
        public DbSet<HistoricoAcaoUsuario> HistoricoAcaoUsuarios { get; set; }
    }
}
