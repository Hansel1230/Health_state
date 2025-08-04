namespace HealthState.Aplicacion.Clientes.Models
{
    public class AuthorizationRequestModel
    {
        public double ApplicationAmount { get; set; }
        public string AuthorizationType { get; set; }
        public string DocumentNumber { get; set; }
        public string Hospital { get; set; }
        public string? DocumentType { get; set; }
        public string? PolicyNumber { get; set; }
        public int HospitalApplicationId { get; set; }
    }
}
