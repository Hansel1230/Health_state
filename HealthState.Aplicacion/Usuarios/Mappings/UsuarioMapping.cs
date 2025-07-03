using AutoMapper;
using HealthState.Aplicacion.Usuarios.Commands;
using HealthState.Aplicacion.Usuarios.Models;

namespace HealthState.Aplicacion.Usuarios.Mappings
{
    public class UsuarioMapping : Profile
    {
        public UsuarioMapping()
        {
            CreateMap<HealthState.Dominio.Usuario, UsuarioModel>()
                .ForMember(x => x.RolNombre, opt => opt.MapFrom(src => src.Rol.Nombre));
           
            CreateMap<UsuarioCreateCommand, HealthState.Dominio.Usuario>()
                .ForMember(dest => dest.RolId, opt => opt.MapFrom(src => src.RolId))
                .ForMember(dest => dest.Rol, opt => opt.Ignore()); 

            CreateMap<UsuarioUpdateCommand, HealthState.Dominio.Usuario>();

        }
    }
}
