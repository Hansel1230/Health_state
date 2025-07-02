using AutoMapper;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Medico.Models;
using HealthState.Aplicacion.Medico.Queries;
using MediatR;

namespace HealthState.Aplicacion.Medico.Handlers
{
    public class MedicoGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<MedicoGetByIdQuery, MedicoModel>
    {
        public async Task<MedicoModel> Handle(MedicoGetByIdQuery request, CancellationToken cancellationToken)
        {
            var respository = unitOfWork.GetRepository<HealthState.Dominio.Medico>();
            var entity = await respository.FirstAsync(x => x.MedicoId == request.Id);

            return mapper.Map<MedicoModel>(entity);
        }
    }
}
