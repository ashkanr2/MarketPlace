using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class BuyerMedal
{
    public int Id { get; set; }

    public int DiscountPercent { get; set; }

    public int CountOfBuy { get; set; }

    public virtual ICollection<AppUser> AppNetUsers { get; set; } = new List<AppUser>();
}
