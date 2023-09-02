using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class ProductBenMaster
{
    public long ProdBenId { get; set; }

    public double ProdBenPercentage { get; set; }

    public long? ProdBenBenId { get; set; }

    public long? ProdBenProductId { get; set; }

    public virtual BeneficiaryMaster? ProdBenBen { get; set; }

    public virtual ProductMaster? ProdBenProduct { get; set; }
}
