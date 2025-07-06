using AutoMapper;
using HealthState.Aplicacion.Tratamiento.Commands;
using HealthState.Aplicacion.Tratamiento.Models;

namespace HealthState.Aplicacion.Tratamiento.Mappings
{
    public class TratamientoMapping : Profile
    {
        public TratamientoMapping()
        {
            CreateMap<HealthState.Dominio.Tratamiento, TratamientoModel>();

            CreateMap<TratamientoCreateCommand, HealthState.Dominio.Tratamiento>();
            CreateMap<TratamientoUpdateCommand, HealthState.Dominio.Tratamiento>();
        }
    }
}