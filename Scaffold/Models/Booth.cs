using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class Booth
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int OwnerUserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Description { get; set; } = null!;

    public int TotalSalesNumber { get; set; }

    public int? BoothImageId { get; set; }

    public bool IsDeleted { get; set; }

    public int CityId { get; set; }

    public bool IsCreated { get; set; }

    public virtual Image? BoothImage { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual AppUser OwnerUser { get; set; } = null!;
}
