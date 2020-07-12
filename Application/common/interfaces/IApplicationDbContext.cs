using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Application.common
{
    public interface IApplicationDbContext
    {
        DbSet<Invoice>Invoicestbl{get;set;}
        DbSet<InvoiceItem>InvoiceItemstbl{get;set;}
        Task<int>  SaveChangesAsync(CancellationToken conselationToken);
        //cansellationToken ekata system.threading kiyana eka use karanna one
    }
}