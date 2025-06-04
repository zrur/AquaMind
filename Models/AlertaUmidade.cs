namespace AquaMind.API.Models
{
    public class AlertaUmidade
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string? Mensagem { get; set; }
        public DateTime DataAlerta { get; set; } = DateTime.Now;
        public bool Lido { get; set; } = false;
        public DateTime? DataLeitura { get; set; }
        public string Prioridade { get; set; } = "MEDIA";
        public int ZonaId { get; set; }
    }
}
