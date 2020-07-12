using System.Collections.Generic;
using System.Linq;
using Application.viewModel;
using FluentValidation.Validators;

namespace Application.invoices.validators
{
    public class InvoiceItemPropertyValidator : PropertyValidator
    {
        public InvoiceItemPropertyValidator():base("Property {PropertyName} should not be an empty list.")
        {
            
        }

        // meka use karanne item list eke athule tina ewwa null wenawada kiyala check karanna. 
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var list=context.PropertyValue as IList<InvoiceItemVM>;
            return list !=null && list.Any();
        }
    }
}