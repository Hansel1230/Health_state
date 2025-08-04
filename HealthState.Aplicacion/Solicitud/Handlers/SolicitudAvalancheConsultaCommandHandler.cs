using MediatR;
using HealthState.Aplicacion.IntegracionARS.Model;
using HealthState.Aplicacion.Interfaces.Servicios;
using HealthState.Aplicacion.Solicitud.Commands;
using HealthState.Aplicacion.Clientes.Models;

namespace HealthState.Aplicacion.Solicitud.Handlers
{
    public class SolicitudAvalancheConsultaCommandHandler : IRequestHandler<SolicitudAvalancheConsultaCommand, RespuestaSolicitud>
    {
        private readonly IAvalancheService _avalancheService;

        public SolicitudAvalancheConsultaCommandHandler(IAvalancheService avalancheService)
        {
            _avalancheService = avalancheService;
        }

        public async Task<RespuestaSolicitud> Handle(SolicitudAvalancheConsultaCommand request, CancellationToken cancellationToken)
        {
            var avalancheRequest = new AuthorizationRequestModel
            {
                ApplicationAmount = (double)request.MontoSolicitud,
                AuthorizationType = request.TipoSolicitud.ToUpper(),
                DocumentNumber = request.NumeroDocumento,
                DocumentType = request.TipoDocumento,
                Hospital = "HospitalName", // Ajusta según tu contexto
                HospitalApplicationId = 0, // Si tienes un ID de solicitud, pásalo aquí
                PolicyNumber = request.NumeroPoliza?.ToString()
            };

            var avalancheResponse = await _avalancheService.MakeAuthorizationAsync(avalancheRequest, cancellationToken);

            return new RespuestaSolicitud
            {
                Estado = avalancheResponse.AuthorizationStatus,
                TipoDocumento = avalancheResponse.DocumentType,
                NumeroDocumento = avalancheResponse.DocumentNumber,
                NumeroPoliza = avalancheResponse.PolicyNumber,
                TipoSolicitud = avalancheResponse.AuthorizationType,
                Descripcion = request.Descripcion,
                Observaciones = request.Observaciones,
                MontoSolicitud = (decimal)avalancheResponse.ApplicationAmount,
                MontoAprobado = (decimal?)avalancheResponse.ApprovedAmount,
                Hospital = avalancheResponse.Hospital
            };
        }
    }
}