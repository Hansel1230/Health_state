using AutoMapper;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Paciente.Models;
using HealthState.Aplicacion.Paciente.Queries;
using MediatR;
using HealthState.Dominio; 

namespace HealthState.Aplicacion.Paciente.Handlers
{
    public class PacienteGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<PacienteGetAllQuery, IEnumerable<PacienteModel>>
    {
        public async Task<IEnumerable<PacienteModel>> Handle(PacienteGetAllQuery request, CancellationToken cancellationToken)
        {
            //var repository = unitOfWork.GetRepository<Paciente>();
            var repository = unitOfWork.GetRepository<HealthState.Dominio.Paciente>();
            var data = await repository.GetAsync(orderBy: x => x.OrderBy(x => x.Nombre));
            return data.Select(x => mapper.Map<PacienteModel>(x));
        }
    }
}
