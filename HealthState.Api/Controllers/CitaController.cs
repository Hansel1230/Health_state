using HealthState.Aplicacion.Cita.Commands;
using HealthState.Aplicacion.Cita.Models;
using HealthState.Aplicacion.Cita.Queries;
using HealthState.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthState.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CitaController : ApiController
    {
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CitaModel>>> Get([FromQuery] CitaGetAllQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CitaModel>> Get(int id)
        {
            var query = new CitaGetByIdQuery(id);
            var response = await Mediator.Send(query);
            return response == null ? NotFound() : Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<CitaModel>> Post(CitaCreateCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CitaModel>> Put(int id, CitaUpdateCommand command)
        {
            command.CitaId = id;
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new CitaDeleteCommand { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
