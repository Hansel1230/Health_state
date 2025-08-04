namespace HealthState.Aplicacion.Clientes.Models
{
    public class CoverageModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public double AmountLimit { get; set; }
        public int YearFrequencyLimit { get; set; }
        public double CoveragePercentage { get; set; }
    }
}
