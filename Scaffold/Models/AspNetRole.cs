using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class AspNetRole
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; set; } = new List<AspNetRoleClaim>();

    public virtual ICollection<AppUser> Users { get; set; } = new List<AppUser>();
}
