namespace HealthState.Aplicacion.Auth.Models
{
    public class AuthApiResponse<T>
    {
        public string Message { get; set; }
        public T Result { get; set; }
        public bool Completed { get; set; }
    }
}
