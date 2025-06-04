namespace AquaMind.API.Models
{
    public class LogAcaoBomba
    {
        public int Id { get; set; }
        public string Acao { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public DateTime DataAcao { get; set; } = DateTime.Now;
        public string? UsuarioAcao { get; set; }
        public bool Automatica { get; set; } = false;
        public int BombaId { get; set; }
    }
}
