using AutoMapper;
using HealthState.Aplicacion.Medico.Commands;
using HealthState.Aplicacion.Medico.Models;

namespace HealthState.Aplicacion.Medico.Mappings
{
    public class MedicoMapping : Profile
    {
        public MedicoMapping()
        {
            CreateMap<HealthState.Dominio.Medico, MedicoModel>();
            CreateMap<MedicoCreateCommand, HealthState.Dominio.Medico>();
            CreateMap<MedicoUpdateCommand, HealthState.Dominio.Medico>();

        }
    }
}
