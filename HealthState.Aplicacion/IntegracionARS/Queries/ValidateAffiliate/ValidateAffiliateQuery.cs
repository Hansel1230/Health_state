using HealthState.Aplicacion.Clientes.Models;
using HealthState.Aplicacion.Interfaces.Servicios;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HealthState.Aplicacion.IntegracionARS.Queries.ValidateAffiliate
{
    public class ValidateAffiliateQuery : IRequest<ValidateAffiliateQueryResponse>
    {
        public string? DocumentType { get; set; }

        [Required(ErrorMessage = "Debe de ingresar el número de documento")]
        public string DocumentNumber { get; set; }
        public string? PolicyNumber { get; set; }
    }

    public class ValidateAffiliateQueryHandler : IRequestHandler<ValidateAffiliateQuery, ValidateAffiliateQueryResponse>
    {
        private readonly IAvalancheService _avalancheService;

        public ValidateAffiliateQueryHandler(IAvalancheService avalancheService)
        {
            _avalancheService = avalancheService;
        }

        public async Task<ValidateAffiliateQueryResponse> Handle(ValidateAffiliateQuery query, CancellationToken cancellationToken)
        {
            try
            {
                ValidateAffiliateQueryResponse result = new();

                ValidateAffiliateRequestModel request = new()
                {
                    DocumentType = query.DocumentType,
                    DocumentNumber = query.DocumentNumber,
                    PolicyNumber = query.PolicyNumber
                };

                var entity = await _avalancheService.ValidateAffiliateAsync(request);

                result.AffiliateModel = entity;

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
