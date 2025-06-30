using MediatR;

namespace HealthState.Aplicacion.Aseguradora.Commands
{
    public class AseguradoraDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
