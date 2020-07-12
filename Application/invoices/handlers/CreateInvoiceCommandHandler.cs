using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.common;
using Application.invoices.commands;
using Domain.Entities;
using MediatR;

namespace Application.invoices.handlers
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommands, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateInvoiceCommandHandler(IApplicationDbContext context)
        {
            this._context = context;

        }

        public async Task<int> Handle(CreateInvoiceCommands request, CancellationToken cancellationToken)
        {
            var entity= new Invoice{
                AmountPaid=request.AmountPaid,
                Date=request.Date,
                Discount=request.Discount,
                DiscountTypes=request.DiscountTypes,
                DueDate=request.DueDate,
                From=request.From,
                InvoiceNumber=request.InvoiceNumber,
                Logo=request.Logo,
                PaymentTerms=request.PaymentTerms,
                Tax=request.Tax,
                To=request.To,
                TaxTypes=request.TaxTypes,
                InvoiceItems=request.InvoiceItems.Select(i=>new InvoiceItem{
                    Item=i.Item,
                    Quantity=i.Quantity,
                    Rate=i.Rate
                    
                }).ToList()
            };

            _context.Invoicestbl.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
            
        }
    }
}