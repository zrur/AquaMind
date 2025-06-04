namespace AquaMind.API.Models
{
    public class Propriedade
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? CEP { get; set; }
        public decimal? AreaTotal { get; set; }
        public bool Ativa { get; set; } = true;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public int UsuarioId { get; set; }
        public int EstadoId { get; set; }
    }
}
