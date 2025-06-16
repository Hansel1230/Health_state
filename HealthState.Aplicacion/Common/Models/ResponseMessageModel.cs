namespace HealthState.Aplicacion.Common.Models
{
    public class ResponseMessageModel<T>
    {
        public ResponseMessageModel(int statusCode, string statusMessage, T content)
        {
            StatusCode = statusCode;
            StatusMessage = statusMessage;
            Content = content;
        }

        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public T Content { get; set; }
    }
}
