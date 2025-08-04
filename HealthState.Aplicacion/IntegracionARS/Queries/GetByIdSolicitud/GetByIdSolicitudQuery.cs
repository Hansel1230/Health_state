using HealthState.Aplicacion.Interfaces.Servicios;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HealthState.Aplicacion.IntegracionARS.Queries.GetByIdSolicitud
{
    public class GetByIdSolicitudQuery : IRequest<GetByIdSolicitudQueryResponse>
    {
        [Required(ErrorMessage = "Debe de ingresar el identificador único")]
        public int Id { get; set; }
    }

    public class GetByIdSolicitudQueryHandler : IRequestHandler<GetByIdSolicitudQuery, GetByIdSolicitudQueryResponse>
    {
        private readonly IAvalancheService _avalancheService;

        public GetByIdSolicitudQueryHandler(IAvalancheService avalancheService)
        {
            _avalancheService = avalancheService;
        }

        public async Task<GetByIdSolicitudQueryResponse> Handle(GetByIdSolicitudQuery query, CancellationToken cancellationToken)
        {
            try
            {
                GetByIdSolicitudQueryResponse result = new();

                var entity = await _avalancheService.GetAuthorizationAsync(query.Id);

                result = entity;

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
