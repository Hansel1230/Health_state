using AutoMapper;
using HealthState.Aplicacion.Rol.Models;
using HealthState.Aplicacion.Solicitud.Commands;
using HealthState.Aplicacion.Solicitud.Models;

namespace HealthState.Aplicacion.Solicitud.Mappings
{
    public class SolicitudMapping : Profile
    {
        public SolicitudMapping()
        {
            CreateMap<HealthState.Dominio.Role, RolModel>();


            CreateMap<HealthState.Dominio.Solicitude, SolicitudModel>()
                .ForMember(dest => dest.Cedula,
                           opt => opt.MapFrom(src => src.Paciente.Cedula != null ? src.Paciente.Cedula : null));
            CreateMap<SolicitudCreateCommand, HealthState.Dominio.Solicitude>();
            CreateMap<SolicitudUpdateCommand, HealthState.Dominio.Solicitude>();
        }
    }
}
