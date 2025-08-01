using AutoMapper;
using HealthState.Aplicacion.Rol.Models;
using HealthState.Aplicacion.Solicitud.Commands;
using HealthState.Aplicacion.Solicitud.Models;
using HealthState.Dominio.Enum;

namespace HealthState.Aplicacion.Solicitud.Mappings
{
    public class SolicitudMapping : Profile
    {
        public SolicitudMapping()
        {
            CreateMap<HealthState.Dominio.Role, RolModel>();


            CreateMap<HealthState.Dominio.Solicitude, SolicitudModel>()
                .ForMember(dest => dest.Cedula,
                           opt => opt.MapFrom(src => src.Paciente.Cedula != null ? src.Paciente.Cedula : null))
                .ForMember(x => x.Estado, opt => opt.MapFrom(src => src.Estado.Descripcion))
                .ForMember(x => x.Aseguradora, opt => opt.MapFrom(src => src.Aseguradora.Nombre))
                .ForMember(x => x.TipoSolicitud, opt => opt.MapFrom(src => src.Tipo.Descripcion));

            CreateMap<SolicitudCreateCommand, HealthState.Dominio.Solicitude>();
            CreateMap<SolicitudUpdateCommand, HealthState.Dominio.Solicitude>();
        }
    }
}
