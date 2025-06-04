namespace AquaMind.API.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string? Modelo { get; set; }
        public string? Localizacao { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataInstalacao { get; set; } = DateTime.Now;
        public DateTime? DataUltimaLeitura { get; set; }
        public int ZonaId { get; set; }
    }
}
