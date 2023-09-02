using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class RoyaltyCalculation
{
    public long RoycalId { get; set; }

    public double BasePrice { get; set; }

    public int Qty { get; set; }

    public double RoyaltyOnBasePrice { get; set; }

    public DateOnly? RoycalTrandate { get; set; }

    public double SalePrice { get; set; }

    public string? TranType { get; set; }

    public long? BenId { get; set; }

    public long? RoyaltyId { get; set; }

    public long? ProductId { get; set; }

    public virtual BeneficiaryMaster? Ben { get; set; }

    public virtual ProductMaster? Product { get; set; }

    public virtual InvoiceTable? Royalty { get; set; }
}
