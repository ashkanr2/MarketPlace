using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class BuyerMedal
{
    public int Id { get; set; }

    public int DiscountPercent { get; set; }

    public int CountOfBuy { get; set; }

    public virtual ICollection<AppUser> AppUsers { get; set; } = new List<AppUser>();
}
