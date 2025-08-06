using AutoMapper;
using HealthState.Aplicacion.Common.Exceptions;
using HealthState.Aplicacion.Common.Interfaces;
using HealthState.Aplicacion.Common.Resources;
using HealthState.Aplicacion.Cita.Commands;
using HealthState.Aplicacion.Cita.Models;
using MediatR;

namespace HealthState.Aplicacion.Cita.Handlers
{
    internal class CitaUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CitaUpdateCommand, CitaModel>
    {
        public async Task<CitaModel> Handle(CitaUpdateCommand request, CancellationToken cancellationToken)
        {
            var repositoryCita = unitOfWork.GetRepository<HealthState.Dominio.Cita>();

            var entityCita = await repositoryCita.FirstAsync(x => x.CitaId == request.CitaId);

            if (entityCita == null)
                throw NotFoundException.Instance(string.Format(MessageResource.EntityToUpdateOrDeleteNotExist));

            var repositoryPaciente = unitOfWork.GetRepository<HealthState.Dominio.Paciente>();

            if (!await repositoryPaciente.ExistAsync(x => x.Cedula == request.PacienteCedula))
                throw NotFoundException.Instance(string.Format(MessageResource.EntityReferencedNotExist, "paciente", request.PacienteCedula));

            var repositoryMedico = unitOfWork.GetRepository<HealthState.Dominio.Medico>();

            if (!await repositoryMedico.ExistAsync(x => x.Cedula == request.MedicoCedula))
                throw NotFoundException.Instance(string.Format(MessageResource.EntityReferencedNotExist, "medico", request.MedicoCedula));

            var entityPaciente = await repositoryPaciente.FirstAsync(x => x.Cedula == request.PacienteCedula);
            var entityMedico = await repositoryMedico.FirstAsync(x => x.Cedula == request.MedicoCedula);

            entityCita.PacienteId = entityPaciente.PacienteId;
            entityCita.MedicoId = entityMedico.MedicoId;

            mapper.Map(request, entityCita);

            await unitOfWork.SaveChangesAsync();

            return mapper.Map<CitaModel>(entityCita);
        }
    }
}
