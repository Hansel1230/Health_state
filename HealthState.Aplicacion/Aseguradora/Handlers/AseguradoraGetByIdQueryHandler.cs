using AutoMapper;
using HealthState.Aplicacion.Aseguradora.Models;
using HealthState.Aplicacion.Aseguradora.Queries;
using HealthState.Aplicacion.Common.Interfaces;
using MediatR;

namespace HealthState.Aplicacion.Aseguradora.Handlers
{
    public class AseguradoraGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AseguradoraGetByIdQuery, AseguradoraModel>
    {
        public async Task<AseguradoraModel> Handle(AseguradoraGetByIdQuery request, CancellationToken cancellationToken)
        {
            var respository = unitOfWork.GetRepository<HealthState.Dominio.Aseguradora>();
            var entity = await respository.FirstAsync(x => x.AseguradoraId == request.Id);

            return mapper.Map<AseguradoraModel>(entity);
        }
    }
}
