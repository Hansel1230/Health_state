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
        public async Task<ActionResult<IEnumerable<PacienteModel>>> Get()
        {
            var query = new PacienteGetAllQuery();
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
