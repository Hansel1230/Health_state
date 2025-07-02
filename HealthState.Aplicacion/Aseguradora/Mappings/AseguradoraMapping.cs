using AutoMapper;
using HealthState.Aplicacion.Aseguradora.Commands;
using HealthState.Aplicacion.Aseguradora.Models;

namespace HealthState.Aplicacion.Aseguradora.Mappings
{
    public class AseguradoraMapping : Profile
    {
        public AseguradoraMapping()
        {
            CreateMap<HealthState.Dominio.Aseguradora, AseguradoraModel>();

            CreateMap<AseguradoraCreateCommand, HealthState.Dominio.Aseguradora>();
            CreateMap<AseguradoraUpdateCommand, HealthState.Dominio.Aseguradora>();
            //CreateMap<AseguradoraDeleteCommand, HealthState.Dominio.Aseguradora>();
        }
    }
}
