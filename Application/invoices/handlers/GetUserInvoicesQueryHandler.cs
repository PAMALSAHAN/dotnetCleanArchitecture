using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.common;
using Application.invoices.queries;
using Application.viewModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.invoices.handlers
{
    public class GetUserInvoicesQueryHandler : IRequestHandler<GetUserInvoicesQuery, IList<InvoiceVM>>
    {
        private readonly IApplicationDbContext _context;

        //db context eka use karanawa
        public GetUserInvoicesQueryHandler(IApplicationDbContext context)
        {
            this._context = context;

        }
        public async Task<IList<InvoiceVM>> Handle(GetUserInvoicesQuery request, CancellationToken cancellationToken)
        {
            var invoices = await _context.Invoicestbl.Include(i => i.InvoiceItems)
                .Where(i => i.CreatedBy == request.User).ToListAsync();
            var vm = invoices.Select(i => new InvoiceVM
            {
                AmountPaid = i.AmountPaid,
                Date = i.Date,
                Discount = i.Discount,
                DiscountTypes = i.DiscountTypes,
                DueDate = i.DueDate,
                From = i.From,
                Id = i.Id,
                InvoiceNumber = i.InvoiceNumber,
                Logo = i.Logo,
                PaymentTerms = i.PaymentTerms,
                Tax = i.Tax,
                TaxTypes = i.TaxTypes,
                To = i.To,
                InvoiceItems = i.InvoiceItems.Select(i => new InvoiceItemVM
                {
                    Id = i.Id,
                    Item = i.Item,
                    Quantity = i.Quantity,
                    Rate = i.Rate
                }).ToList()
            }).ToList();
            return vm;
        }
    }
}