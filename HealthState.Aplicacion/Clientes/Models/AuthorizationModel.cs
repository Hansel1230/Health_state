namespace HealthState.Aplicacion.Clientes.Models
{
    public class AuthorizationModel
    {
        public int Number { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
        public string AuthorizationType { get; set; }
        public double ApplicationAmount { get; set; }
        public double? ApprovedAmount { get; set; }
        public string Affiliate { get; set; }
        public string Policy { get; set; }
        public string Hospital { get; set; }
    }
}
