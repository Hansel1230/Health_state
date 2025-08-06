using MediatR;
using HealthState.Aplicacion.IntegracionARS.Model;
using HealthState.Aplicacion.Interfaces.Servicios;

namespace HealthState.Aplicacion.IntegracionARS.Commands.PayBills
{
    public class PayBillsCommandHandler : IRequestHandler<PayBillsCommand, PayBillResponseDTO>
    {
        private readonly IAvalancheService _avalancheService;

        public PayBillsCommandHandler(IAvalancheService avalancheService)
        {
            _avalancheService = avalancheService;
        }

        public async Task<PayBillResponseDTO> Handle(PayBillsCommand request, CancellationToken cancellationToken)
        {
            return await _avalancheService.PayBillsAsync(request.Request, cancellationToken);
        }
    }
}