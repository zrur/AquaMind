namespace AquaMind.API.Models
{
    public class Bomba
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Modelo { get; set; }
        public decimal? Potencia { get; set; }
        public string? Localizacao { get; set; }
        public bool Ativa { get; set; } = true;
        public bool Ligada { get; set; } = false;
        public DateTime DataInstalacao { get; set; } = DateTime.Now;
        public DateTime? DataUltimaManutencao { get; set; }
        public int ZonaId { get; set; }
    }
}
