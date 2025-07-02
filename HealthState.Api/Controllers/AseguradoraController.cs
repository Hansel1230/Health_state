using HealthState.Aplicacion.Aseguradora.Commands;
using HealthState.Aplicacion.Aseguradora.Models;
using HealthState.Aplicacion.Aseguradora.Queries;
using HealthState.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HealthState.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AseguradoraController : ApiController
    {
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<AseguradoraModel>>> Get([FromQuery] AseguradoraGetAllQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AseguradoraModel>> Get(int id)
        {
            var query = new AseguradoraGetByIdQuery(id);
            var response = await Mediator.Send(query);
            return response == null ? NotFound() : Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<AseguradoraModel>> Post(AseguradoraCreateCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<AseguradoraModel>> Put(int id, AseguradoraUpdateCommand command)
        {
            command.AseguradoraId = id;
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new AseguradoraDeleteCommand { Id = id};
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
