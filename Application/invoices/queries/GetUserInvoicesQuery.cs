using System.Collections.Generic;
using Application.viewModel;
using MediatR;

namespace Application.invoices.queries
{
    public class GetUserInvoicesQuery :IRequest<IList<InvoiceVM>>
    {
        public string User { get; set; }
    }
}