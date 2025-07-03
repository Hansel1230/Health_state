using HealthState.Aplicacion.Rol.Commands;
using HealthState.Aplicacion.Rol.Models;
using HealthState.Aplicacion.Rol.Queries;
using HealthState.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthState.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolController : ApiController
    {
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<RolModel>>> Get([FromQuery] RolGetAllQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RolModel>> Get(int id)
        {
            var query = new RolGetByIdQuery(id);
            var response = await Mediator.Send(query);
            return response == null ? NotFound() : Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<RolModel>> Post(RolCreateCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<RolModel>> Put(int id, RolUpdateCommand command)
        {
            command.RolId = id;
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new RolDeleteCommand { Id = id};
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
