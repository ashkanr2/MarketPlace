using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int BoothId { get; set; }

    public DateTime CreateTime { get; set; }

    public virtual Booth Booth { get; set; } = null!;

    public virtual ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

    public virtual AppUser User { get; set; } = null!;
}
