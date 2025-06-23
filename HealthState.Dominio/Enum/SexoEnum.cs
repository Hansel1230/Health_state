using System.ComponentModel;
using System.Text.Json.Serialization;

namespace HealthState.Dominio.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SexoEnum
    {
        [Description("Masculino")] M,
        [Description("Femenino")] F,
    }
}
