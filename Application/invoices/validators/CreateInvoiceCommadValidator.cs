using Application.invoices.commands;
using FluentValidation;

namespace Application.invoices.validators
{
    public class CreateInvoiceCommadValidator :AbstractValidator<CreateInvoiceCommands>
    {
        public CreateInvoiceCommadValidator()
        {
            RuleFor(x=>x.AmountPaid).NotNull();
        
            RuleFor(x=>x.InvoiceNumber).NotNull();
            RuleFor(x=>x.From).NotEmpty().MinimumLength(3);
            RuleFor(x=>x.To).NotEmpty().MinimumLength(3);
            //meka wenama class ekaka tinawa. 
            RuleFor(x=>x.InvoiceItems).SetValidator(new InvoiceItemPropertyValidator()); 
            
        }  
    }
}