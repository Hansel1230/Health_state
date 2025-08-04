using HealthState.Aplicacion.Common.Models;

namespace HealthState.Aplicacion.Clientes.Models
{
    public class AuthorizationResponseModel
    {
        public string Id { get; set; }
        public string? DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string? PolicyNumber { get; set; }
        public string AuthorizationType { get; set; }
        public double ApplicationAmount { get; set; }
        public double? ApprovedAmount { get; set; }
        public string AuthorizationStatus { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Hospital { get; set; }
        public string Status { get; set; }
        public List<DetailModel> Details { get; set; }
    }
}
