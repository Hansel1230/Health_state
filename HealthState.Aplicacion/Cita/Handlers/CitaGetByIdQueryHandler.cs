using AutoMapper;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Cita.Models;
using HealthState.Aplicacion.Cita.Queries;
using MediatR;

namespace HealthState.Aplicacion.Cita.Handlers
{
    public class CitaGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CitaGetByIdQuery, CitaModel>
    {
        public async Task<CitaModel> Handle(CitaGetByIdQuery request, CancellationToken cancellationToken)
        {
            var respository = unitOfWork.GetRepository<HealthState.Dominio.Cita>();
            var entity = await respository.FirstAsync(x => x.CitaId == request.Id);

            return mapper.Map<CitaModel>(entity);
        }
    }
}
