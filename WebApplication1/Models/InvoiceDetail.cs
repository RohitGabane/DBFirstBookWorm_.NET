using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class InvoiceDetail
{
    public long InvDtlId { get; set; }

    public double BasePrice { get; set; }

    public int Quantity { get; set; }

    public int RentNoOfDays { get; set; }

    public string? TranType { get; set; }

    public long? InvoiceId { get; set; }

    public long? ProductId { get; set; }

    public virtual InvoiceTable? Invoice { get; set; }

    public virtual ProductMaster? Product { get; set; }
}
