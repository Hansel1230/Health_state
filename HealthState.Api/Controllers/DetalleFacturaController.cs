using HealthState.Aplicacion.DetalleFactura.Commands;
using HealthState.Aplicacion.DetalleFactura.Models;
using HealthState.Aplicacion.DetalleFactura.Queries;
using HealthState.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthState.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DetalleFacturaController : ApiController
    {
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<DetalleFacturaModel>>> Get([FromQuery] DetalleFacturaGetAllQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DetalleFacturaModel>> Get(int id)
        {
            var query = new DetalleFacturaGetByIdQuery(id);
            var response = await Mediator.Send(query);
            return response == null ? NotFound() : Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<DetalleFacturaModel>> Post(DetalleFacturaCreateCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<DetalleFacturaModel>> Put(int id, DetalleFacturaUpdateCommand command)
        {
            command.DetalleId = id;
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DetalleFacturaDeleteCommand { Id = id};
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
