using AutoMapper;
using HealthState.Aplicacion.Factura.Commands;
using HealthState.Aplicacion.Factura.Models;

namespace HealthState.Aplicacion.Factura.Mappings
{
    public class FacturaMapping : Profile
    {
        public FacturaMapping()
        {
            CreateMap<HealthState.Dominio.Factura, FacturaModel>();

            CreateMap<FacturaCreateCommand, HealthState.Dominio.Factura>();
            CreateMap<FacturaUpdateCommand, HealthState.Dominio.Factura>();
        }
    }
}
