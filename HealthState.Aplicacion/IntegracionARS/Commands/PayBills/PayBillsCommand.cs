using AutoMapper;
using HealthState.Aplicacion.Clientes.Constantes;
using HealthState.Aplicacion.Clientes.Models;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.IntegracionARS.Commands.MakeAuthorization;
using HealthState.Aplicacion.IntegracionARS.Model;
using HealthState.Aplicacion.Interfaces.Servicios;
using HealthState.Dominio.Enum;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HealthState.Aplicacion.IntegracionARS.Commands.PayBills
{
    public class PayBillsCommand : IRequest<PayBillResponseDTO>
    {
        public PayBillRequestModel Request { get; }
        public PayBillsCommand(PayBillRequestModel request) => Request = request;
    }
}
