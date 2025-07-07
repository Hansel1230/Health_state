using AutoMapper;
using HealthState.Aplicacion.DetalleFactura.Commands;
using HealthState.Aplicacion.DetalleFactura.Models;

namespace HealthState.Aplicacion.Factura.Mappings
{
    public class DetalleFacturaMapping : Profile
    {
        public DetalleFacturaMapping()
        {
            CreateMap<HealthState.Dominio.DetalleFactura, DetalleFacturaModel>();

            CreateMap<DetalleFacturaCreateCommand, HealthState.Dominio.DetalleFactura>();
            CreateMap<DetalleFacturaUpdateCommand, HealthState.Dominio.DetalleFactura>();
        }
    }
}
