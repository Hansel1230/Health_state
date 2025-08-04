using HealthState.Aplicacion.Common.Models;

namespace HealthState.Aplicacion.Clientes.Models
{
    public class AffiliateModel
    {
        public string Status { get; set; }
        public List<DetailModel> Details { get; set; }
        public bool Exists { get; set; }
        public string Name { get; set; }
        public DateTime AffiliateDate { get; set; }
        public string Number { get; set; }
        public string PolicyStatus { get; set; }
        public string Plan { get; set; }
        public List<CoverageModel> Coverages { get; set; }
    }
}
