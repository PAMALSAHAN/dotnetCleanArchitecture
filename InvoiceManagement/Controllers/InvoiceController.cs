using System.Threading.Tasks;
using Application.invoices.commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagement.Controllers
{
    [Authorize]
    public class InvoiceController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateInvoiceCommands command)
        {
            return await Mediator.Send(command);
        } 
    }
}