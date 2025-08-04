namespace HealthState.Aplicacion.IntegracionARS.Model
{
    public class PayBillRequestModel
    {
        public List<PayBillItem> Bills { get; set; }
        public string Hospital { get; set; }
    }

    public class PayBillItem
    {
        public int AuthorizationNumber { get; set; }
        public decimal Amount { get; set; }
    }
}