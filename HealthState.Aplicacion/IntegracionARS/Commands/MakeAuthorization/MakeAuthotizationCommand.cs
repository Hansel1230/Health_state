using AutoMapper;
using HealthState.Aplicacion.Clientes.Constantes;
using HealthState.Aplicacion.Clientes.Models;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.IntegracionARS.Model;
using HealthState.Aplicacion.Interfaces.Servicios;
using HealthState.Aplicacion.Paciente.Models;
using HealthState.Dominio.Enum;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace HealthState.Aplicacion.IntegracionARS.Commands.MakeAuthorization
{
    public class MakeAuthotizationCommand : IRequest<RespuestaSolicitud>
    {
        public string? TipoDocumento { get; set; }

        [Required(ErrorMessage = "Debe ingresar el número del documento.")]
        public string NumeroDocumento { get; set; }
        public int? NumeroPoliza { get; set; }

        [Required(ErrorMessage = "Debe ingresar el tipo de autorización.")]
        public string TipoSolicitud { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }

        [Required(ErrorMessage = "Debe ingresar el monto solicitado.")]
        public decimal MontoSolicitud { get; set; }
    }
}