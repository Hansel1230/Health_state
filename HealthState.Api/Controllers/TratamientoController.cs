using HealthState.Aplicacion.Tratamiento.Commands;
using HealthState.Aplicacion.Tratamiento.Models;
using HealthState.Aplicacion.Tratamiento.Queries;
using HealthState.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthState.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TratamientoController : ApiController
    {
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<TratamientoModel>>> Get([FromQuery] TratamientoGetAllQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TratamientoModel>> Get(int id)
        {
            var query = new TratamientoGetByIdQuery(id);
            var response = await Mediator.Send(query);
            return response == null ? NotFound() : Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<TratamientoModel>> Post(TratamientoCreateCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<TratamientoModel>> Put(int id, TratamientoUpdateCommand command)
        {
            command.TratamientoId = id;
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new TratamientoDeleteCommand { Id = id};
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
