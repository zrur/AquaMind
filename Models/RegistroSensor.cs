namespace AquaMind.API.Models
{
    public class RegistroSensor
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string Unidade { get; set; } = "%";
        public DateTime DataRegistro { get; set; } = DateTime.Now;
        public string? Observacoes { get; set; }
        public int SensorId { get; set; }
    }
}
