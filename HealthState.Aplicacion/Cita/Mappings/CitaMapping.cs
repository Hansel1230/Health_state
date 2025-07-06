using AutoMapper;
using HealthState.Aplicacion.Cita.Commands;
using HealthState.Aplicacion.Cita.Models;

namespace HealthState.Aplicacion.Cita.Mappings
{
    internal class CitaMapping : Profile
    {
        public CitaMapping()
        {
            CreateMap<HealthState.Dominio.Cita, CitaModel>();

            CreateMap<CitaCreateCommand, HealthState.Dominio.Cita>();
            CreateMap<CitaUpdateCommand, HealthState.Dominio.Cita>();
        }
    }
}
