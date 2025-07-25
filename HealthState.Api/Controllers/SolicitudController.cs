﻿using HealthState.Aplicacion.Solicitud.Commands;
using HealthState.Aplicacion.Solicitud.Models;
using HealthState.Aplicacion.Solicitud.Queries;
using HealthState.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthState.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SolicitudController : ApiController
    {
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<SolicitudModel>>> Get([FromQuery] SolicitudGetAllQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SolicitudModel>> Get(int id)
        {
            var query = new SolicitudGetByIdQuery(id);
            var response = await Mediator.Send(query);
            return response == null ? NotFound() : Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<SolicitudModel>> Post(SolicitudCreateCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<SolicitudModel>> Put(int id, SolicitudUpdateCommand command)
        {
            command.SolicitudId = id;
            var response = await Mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new SolicitudDeleteCommand { Id = id};
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
