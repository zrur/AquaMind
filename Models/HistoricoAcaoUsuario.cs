namespace AquaMind.API.Models
{
    public class HistoricoAcaoUsuario
    {
        public int Id { get; set; }
        public string Acao { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public string? Entidade { get; set; }
        public int? EntidadeId { get; set; }
        public string? EnderecoIP { get; set; }
        public string? UserAgent { get; set; }
        public DateTime DataAcao { get; set; } = DateTime.Now;
        public int UsuarioId { get; set; }
    }
}
