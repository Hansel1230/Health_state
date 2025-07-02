using MediatR;

namespace HealthState.Aplicacion.Medico.Commands
{
    public class MedicoDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}

