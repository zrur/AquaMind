namespace AquaMind.API.Models
{
    public class Zona
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal? Area { get; set; }
        public string? TipoCultura { get; set; }
        public bool Ativa { get; set; } = true;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public int PropriedadeId { get; set; }
    }
}
