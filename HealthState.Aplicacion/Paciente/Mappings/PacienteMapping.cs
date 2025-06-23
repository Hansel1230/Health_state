using AutoMapper;
using HealthState.Aplicacion.Paciente.Models;

namespace HealthState.Aplicacion.Paciente.Mappings
{
    public class PacienteMapping : Profile
    {
        public PacienteMapping()
        {
            CreateMap<HealthState.Dominio.Paciente, PacienteModel>();
        }
    }
}
