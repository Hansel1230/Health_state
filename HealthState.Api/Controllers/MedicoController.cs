using HealthState.Aplicacion.Medico.Commands;
using HealthState.Aplicacion.Medico.Models;
using HealthState.Aplicacion.Medico.Queries;
using HealthState.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HealthState.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MedicoController : ApiController
    {
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<MedicoModel>>> Get([FromQuery] MedicoGetAllQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MedicoModel>> Get(int id)
        {
            var query = new MedicoGetByIdQuery(id);
            var response = await Mediator.Send(query);
            return response == null ? NotFound() : Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<MedicoModel>> Post(MedicoCreateCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<MedicoModel>> Put(int id, MedicoUpdateCommand command)
        {
            command.MedicoId = id;
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new MedicoDeleteCommand { Id = id};
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
