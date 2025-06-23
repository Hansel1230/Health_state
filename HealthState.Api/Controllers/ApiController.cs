using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthState.Controllers
{
    public class ApiController : ControllerBase
    {
        private IMediator mediator;
        public IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
