using HealthState.Aplicacion.Usuarios.Models;
using MediatR;

namespace HealthState.Aplicacion.Usuarios.Queries
{
    public record UsuarioGetByIdQuery(int id) : IRequest<UsuarioModel> { }
}
