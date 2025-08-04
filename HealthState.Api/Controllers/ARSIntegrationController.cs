using HealthState.Aplicacion.IntegracionARS.Queries.GetByIdSolicitud;
using HealthState.Aplicacion.IntegracionARS.Queries.ValidateAffiliate;
using HealthState.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthState.Api.Controllers
{
    [Route("api/ars")]
    [ApiController]
    [Authorize]
    public class ARSIntegrationController : ApiController
    {
        [HttpGet("solicitud/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var response = await Mediator.Send(new GetByIdSolicitudQuery() { Id = id });
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        [HttpGet("validar-afiliado")]
        public async Task<IActionResult> ValidateAffiliate([FromQuery] ValidateAffiliateQuery query)
        {
            try
            {
                var response = await Mediator.Send(query);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
