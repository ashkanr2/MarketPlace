using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Product
{
    public int Id { get; set; }

    public int UnitPrice { get; set; }

    public int BoothId { get; set; }

    public int AllProductId { get; set; }

    public DateTime? AddTime { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsAccepted { get; set; }

    public virtual AllProduct AllProduct { get; set; } = null!;

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
}
