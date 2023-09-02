using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class BeneficiaryMaster
{
    public long BenId { get; set; }

    public string? BenAccNo { get; set; }

    public string? BenAccType { get; set; }

    public string? BenBankBranch { get; set; }

    public string? BenBankName { get; set; }

    public string? BenContactNo { get; set; }

    public string? BenEmailId { get; set; }

    public string? Benifsc { get; set; }

    public string? BenName { get; set; }

    public string? Benpan { get; set; }

    public virtual ICollection<ProductBenMaster> ProductBenMasters { get; set; } = new List<ProductBenMaster>();

    public virtual ICollection<RoyaltyCalculation> RoyaltyCalculations { get; set; } = new List<RoyaltyCalculation>();
}
