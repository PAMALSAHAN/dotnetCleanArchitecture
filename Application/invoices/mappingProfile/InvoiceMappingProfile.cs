using Application.invoices.commands;
using Application.viewModel;
using AutoMapper;
using Domain.Entities;

namespace Application.invoices.mappingProfile
{
    public class InvoiceMappingProfile :Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice,InvoiceVM>();
            CreateMap<InvoiceItem,InvoiceItemVM>();

            CreateMap<InvoiceVM,Invoice>();
            CreateMap<InvoiceItemVM,InvoiceItem>();

            CreateMap<CreateInvoiceCommands,Invoice>();
        }
    }
}