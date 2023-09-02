using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class InvoiceTable
{
    public long InvoiceId { get; set; }

    public double InvoiceAmount { get; set; }

    public DateOnly? InvoiceDate { get; set; }

    public long? CustId { get; set; }

    public virtual CustomerMaster? Cust { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual ICollection<RoyaltyCalculation> RoyaltyCalculations { get; set; } = new List<RoyaltyCalculation>();
}
