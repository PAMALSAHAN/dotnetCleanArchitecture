using Infrastructure.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Application.common;
using Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using Domain.common;
using System;


namespace Infrastructure.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>,IApplicationDbContext
    {
        private readonly ICurrentUserService currentUserService; 
        // userwa ganna one hinda dependancy 
        // injection use karanawa

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,ICurrentUserService currentUserService) : base(options, operationalStoreOptions)
        {
            this.currentUserService = currentUserService;
        }
        //interface eka init karama mehama thamai
        DbSet<Invoice> IApplicationDbContext.Invoicestbl { get; set; }
        DbSet<InvoiceItem> IApplicationDbContext.InvoiceItemstbl { get; set ; }

        public override Task<int> SaveChangesAsync(CancellationToken conselationToken)
        {
            
            foreach (var entry in ChangeTracker.Entries<AuditEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy=currentUserService.UserId;
                        entry.Entity.Created=DateTime.UtcNow;
                        break;
                    
                    case EntityState.Modified:
                        entry.Entity.LastMadifiedBy=currentUserService.UserId;
                        entry.Entity.LastMadified=DateTime.UtcNow;
                        break;
                        
                    //default eka onema naha.
                }
                
            }
            return base.SaveChangesAsync(conselationToken);
        }
    }
}
