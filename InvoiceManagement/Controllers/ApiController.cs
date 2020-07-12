using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceManagement.Controllers
{
    [Route("api/controller")]
    [ApiController]

    public abstract class ApiController : ControllerBase
    {
        //mediator tika danawa eken anith api inherit karanna puluwan hinda
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }

}

