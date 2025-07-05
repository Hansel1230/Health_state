using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Paciente.Commands;
using HealthState.Aplicacion.Paciente.Models;
using HealthState.Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore; 

namespace HealthState.Aplicacion.Paciente.Handlers
{
    public class PacienteUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<PacienteUpdateCommand, PacienteModel>
    {
        public async Task<PacienteModel> Handle(PacienteUpdateCommand request, CancellationToken cancellationToken)
        {
            var pacienteRepository = unitOfWork.GetRepository<HealthState.Dominio.Paciente>();
            var aseguradoraRepository = unitOfWork.GetRepository<HealthState.Dominio.Aseguradora>();

            var entity = await pacienteRepository.FirstAsync(x => x.PacienteId == request.Id);

            if (entity == null)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist));

            if (await pacienteRepository.ExistAsync(x => x.Cedula == request.Cedula && x.PacienteId != request.Id))
                throw BusinessException.Instance(string.Format(MessageResource.ValueAlreadyRegistered, request.Cedula));
            
            mapper.Map(request, entity);

            if (request.AseguradoraId.HasValue && request.AseguradoraId.Value != 0)
            {
                var aseguradora = await aseguradoraRepository.FirstAsync(x => x.AseguradoraId == request.AseguradoraId);

                if (aseguradora == null)
                    throw NotFoundException.Instance(string.Format(MessageResource.EntityReferencedNotExist, "aseguradora", request.AseguradoraId));

                entity.Aseguradora = aseguradora;
                entity.AseguradoraId = aseguradora.AseguradoraId;
            }
            else
            {
                entity.Aseguradora = null;
                entity.AseguradoraId = null;
            }

            if (request.PolizaId.HasValue && request.PolizaId.Value == 0)
                entity.PolizaId = null; 
            else if (!request.PolizaId.HasValue)
                entity.PolizaId = null; 

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<PacienteModel>(entity);
        }
    }
}