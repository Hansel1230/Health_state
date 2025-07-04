using HealthState.Aplicacion.Factura.Commands;
using HealthState.Aplicacion.Factura.Models;
using HealthState.Aplicacion.Factura.Queries;
using HealthState.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthState.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class FacturaController : ApiController
    {
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<FacturaModel>>> Get([FromQuery] FacturaGetAllQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FacturaModel>> Get(int id)
        {
            var query = new FacturaGetByIdQuery(id);
            var response = await Mediator.Send(query);
            return response == null ? NotFound() : Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<FacturaModel>> Post(FacturaCreateCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<FacturaModel>> Put(int id, FacturaUpdateCommand command)
        {
            command.FacturaId = id;
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new FacturaDeleteCommand { Id = id};
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
