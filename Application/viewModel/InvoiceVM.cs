using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Application.viewModel
{
    public class InvoiceVM
    {
        public InvoiceVM()
        {
            this.InvoiceItems = new List<InvoiceItemVM>();
        }
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string Logo { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string PaymentTerms { get; set; }
        public DateTime DueDate { get; set; }
        public double Discount { get; set; }
        public DiscountTypes DiscountTypes { get; set; }
        public double Tax { get; set; }
        public TaxTypes TaxTypes { get; set; }
        public double AmountPaid { get; set; }
        public IList<InvoiceItemVM> InvoiceItems { get; set; }

    }
}