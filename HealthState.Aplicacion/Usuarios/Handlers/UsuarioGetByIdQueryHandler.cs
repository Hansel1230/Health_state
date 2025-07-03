using AutoMapper;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Usuarios.Models;
using HealthState.Aplicacion.Usuarios.Queries;
using MediatR;

namespace HealthState.Aplicacion.Usuarios.Handlers
{
    public class UsuarioGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UsuarioGetByIdQuery, UsuarioModel>
    {
        public async Task<UsuarioModel> Handle(UsuarioGetByIdQuery request, CancellationToken cancellationToken)
        {
            var respository = unitOfWork.GetRepository<HealthState.Dominio.Usuario>();
            var entity = await respository.FirstAsync(x => x.UsuarioId == request.id,
                includeProperties: [nameof(HealthState.Dominio.Usuario.Rol)]);

            return mapper.Map<UsuarioModel>(entity);
        }
    }
}
