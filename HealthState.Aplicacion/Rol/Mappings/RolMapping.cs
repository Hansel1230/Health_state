using AutoMapper;
using HealthState.Aplicacion.Rol.Commands;
using HealthState.Aplicacion.Rol.Models;

namespace HealthState.Aplicacion.Rol.Mappings
{
    public class RolMapping : Profile
    {
        public RolMapping()
        {
            CreateMap<HealthState.Dominio.Role, RolModel>();
            CreateMap<RolCreateCommand, HealthState.Dominio.Role>();
            CreateMap<RolUpdateCommand, HealthState.Dominio.Role>();

        }
    }
}
