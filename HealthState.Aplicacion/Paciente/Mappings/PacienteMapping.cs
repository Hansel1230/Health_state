using AutoMapper;
using HealthState.Aplicacion.Paciente.Commands;
using HealthState.Aplicacion.Paciente.Models;

namespace HealthState.Aplicacion.Paciente.Mappings
{
    public class PacienteMapping : Profile
    {
        public PacienteMapping()
        {
            CreateMap<HealthState.Dominio.Paciente, PacienteModel>()
                .ForMember(x => x.Aseguradora, opt => opt.MapFrom(src => src.Aseguradora.Nombre));

            CreateMap<PacienteCreateCommand, HealthState.Dominio.Paciente>();

            CreateMap<PacienteUpdateCommand, HealthState.Dominio.Paciente>();
        }
    }
}
