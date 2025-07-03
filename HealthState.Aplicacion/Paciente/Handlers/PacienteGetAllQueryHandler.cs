using AutoMapper;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Models;
using HealthState.Aplicacion.Common.Utils;
using HealthState.Aplicacion.Paciente.Models;
using HealthState.Aplicacion.Paciente.Queries;
using MediatR;

namespace HealthState.Aplicacion.Paciente.Handlers
{
    public class PacienteGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<PacienteGetAllQuery, PaginationResponseModel<PacienteModel>>
    {
        public async Task<PaginationResponseModel<PacienteModel>> Handle(PacienteGetAllQuery request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Paciente>();
            var query = PredicateBuilder.Build<HealthState.Dominio.Paciente>();

            if (!string.IsNullOrEmpty(request.search))
                query = query.And(x => x.Cedula == request.search)
                                .Or(x => x.Nombre.ToLower().Contains(request.search.ToLower()));

            var totalCount = await repository.CountAsync();

            if (totalCount == 0)
                return new PaginationResponseModel<PacienteModel>(Enumerable.Empty<PacienteModel>(), 0);

            var data = await repository.GetAsync(query, orderBy: x => x.OrderByDescending(x => x.PacienteId), 
                skip: request.Skip, take: request.Take, includeProperties: [nameof(HealthState.Dominio.Paciente.Aseguradora)]);
            return new PaginationResponseModel<PacienteModel>(
            mapper.Map<IEnumerable<PacienteModel>>(data),
            totalCount,
            request.Skip,
            request.Take);
        }
    }
}
