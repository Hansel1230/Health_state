using HealthState.Aplicacion.Aseguradora.Models;
using MediatR;

namespace HealthState.Aplicacion.Aseguradora.Queries
{
    public record AseguradoraGetByIdQuery(int Id) : IRequest<AseguradoraModel> { }
}
