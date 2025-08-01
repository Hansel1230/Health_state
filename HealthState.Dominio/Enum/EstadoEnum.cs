using System.Text.Json.Serialization;

namespace HealthState.Dominio.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EstadoEnum
    {
        A = 100,
        R = 101,
        P = 102,

        E = 103,
        C = 104,
        F = 105
    }
}
