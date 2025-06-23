using AutoMapper;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Paciente.Models;
using HealthState.Aplicacion.Paciente.Queries;
using HealthState.Dominio;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthState.Aplicacion.Paciente.Handlers
{
    public class PacienteGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<PacienteGetByIdQuery, PacienteModel>
    {
        public async Task<PacienteModel> Handle(PacienteGetByIdQuery request, CancellationToken cancellationToken)
        {
            var respository = unitOfWork.GetRepository<HealthState.Dominio.Paciente>();
            var entity = await respository.FirstAsync(x => x.PacienteId == request.Id,
                includeProperties: [nameof(HealthState.Dominio.Paciente.Cita)]);

            return mapper.Map<PacienteModel>(entity);
        }
    }
}
