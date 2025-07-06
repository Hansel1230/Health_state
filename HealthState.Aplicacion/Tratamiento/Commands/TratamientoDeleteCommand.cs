using MediatR;

namespace HealthState.Aplicacion.Tratamiento.Commands
{
    public class TratamientoDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
