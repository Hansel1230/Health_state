using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Paciente.Commands;
using HealthState.Aplicacion.Paciente.Models;
using HealthState.Dominio;
using MediatR;

namespace HealthState.Aplicacion.Paciente.Handlers
{
    public class PacienteCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<PacienteCreateCommand, PacienteModel>
    {
        public async Task<PacienteModel> Handle(PacienteCreateCommand request, CancellationToken cancellationToken)
        {
            var pacienteRepository = unitOfWork.GetRepository<HealthState.Dominio.Paciente>();
            var aseguradoraRepository = unitOfWork.GetRepository<Aseguradora>();

            if (await pacienteRepository.ExistAsync(x => x.Cedula == request.Cedula))
                throw BusinessException.Instance(string.Format(MessageResource.ValueAlreadyRegistered, request.Cedula));

            var entity = mapper.Map<HealthState.Dominio.Paciente>(request);

            if (request.AseguradoraId.HasValue && request.AseguradoraId.Value != 0) 
            {
                var aseguradora = await aseguradoraRepository.FirstAsync(x => x.AseguradoraId == request.AseguradoraId.Value);
                if (aseguradora == null)
                    throw BusinessException.Instance(string.Format(MessageResource.EntityReferencedNotExist));

                entity.Aseguradora = aseguradora;
            }
            else
            {
                entity.PolizaId = null;
                entity.AseguradoraId = null;
            }

            await pacienteRepository.InsertAsync(entity);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<PacienteModel>(entity);
        }
    }
}
