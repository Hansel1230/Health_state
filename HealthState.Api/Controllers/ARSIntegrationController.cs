using HealthState.Aplicacion.IntegracionARS.Commands.MakeAuthorization;
using HealthState.Aplicacion.IntegracionARS.Queries.GetByIdSolicitud;
using HealthState.Aplicacion.IntegracionARS.Queries.ValidateAffiliate;
using HealthState.Aplicacion.IntegracionARS.Model;
using HealthState.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HealthState.Aplicacion.IntegracionARS.Commands.PayBills;

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

        [HttpPost("hacer-solicitud")]
        public async Task<IActionResult> MakeAuthorization([FromBody] MakeAuthotizationCommand command)
        {
            try
            {
                var response = await Mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost("pay-bill")]
        public async Task<IActionResult> PayBill([FromBody] PayBillRequestModel request)
        {
            try
            {
                var response = await Mediator.Send(new PayBillsCommand(request));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
