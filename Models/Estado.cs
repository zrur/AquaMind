namespace AquaMind.API.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sigla { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
