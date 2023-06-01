using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class SellerMedal
{
    public int Id { get; set; }

    public int DiscountPercent { get; set; }

    public int CountOfSell { get; set; }

    public virtual ICollection<SellerInformation> SellerInformations { get; set; } = new List<SellerInformation>();
}
