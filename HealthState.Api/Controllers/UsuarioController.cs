using HealthState.Aplicacion.Usuarios.Commands;
using HealthState.Aplicacion.Usuarios.Models;
using HealthState.Aplicacion.Usuarios.Queries;
using HealthState.Controllers;
using HealthState.Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthState.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController : ApiController
    {
        [HttpGet("all")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> Get([FromQuery] UsuarioGetAllQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<ActionResult<UsuarioModel>> Get(int id)
        {
            var query = new UsuarioGetByIdQuery(id);
            var response = await Mediator.Send(query);
            return response == null ? NotFound() : Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Post(UsuarioCreateCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        [Authorize]
        public async Task<ActionResult<UsuarioModel>> Put(int id, UsuarioUpdateCommand command)
        {
            command.UsuarioId = id;
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new UsuarioDeleteCommand { Id = id};
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
