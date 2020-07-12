using System.Collections.Generic;
using System.Threading.Tasks;
using Application.common;
using Application.invoices.commands;
using Application.invoices.queries;
using Application.viewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagement.Controllers
{
    [Authorize]
    public class InvoiceController : ApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public InvoiceController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateInvoiceCommands command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<IList<InvoiceVM>> Get()
        {
            return await Mediator.Send(new GetUserInvoicesQuery { User = _currentUserService.UserId });
        }
    }
}