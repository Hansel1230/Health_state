using HealthState.Aplicacion.Paciente.Commands;
using HealthState.Aplicacion.Paciente.Models;
using HealthState.Aplicacion.Paciente.Queries;
using HealthState.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HealthState.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PacienteController : ApiController
    {
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<PacienteModel>>> Get([FromQuery] PacienteGetAllQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PacienteModel>> Get(int id)
        {
            var query = new PacienteGetByIdQuery(id);
            var response = await Mediator.Send(query);
            return response == null ? NotFound() : Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<PacienteModel>> Post(PacienteCreateCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<PacienteModel>> Put(int id, PacienteUpdateCommand command)
        {
            command.Id = id;
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
