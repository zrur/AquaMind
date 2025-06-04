namespace AquaMind.API.Models
{
    public class ConfiguracaoZona
    {
        public int Id { get; set; }
        public decimal UmidadeMinima { get; set; }
        public decimal UmidadeMaxima { get; set; }
        public TimeSpan TempoIrrigacao { get; set; }
        public TimeSpan? IntervaloIrrigacao { get; set; }
        public bool IrrigacaoAutomatica { get; set; } = true;
        public bool NotificacaoEmail { get; set; } = false;
        public bool NotificacaoSMS { get; set; } = false;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataUltimaAlteracao { get; set; }
        public int ZonaId { get; set; }
    }
}
