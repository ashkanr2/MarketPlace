using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime OrderCreatTime { get; set; }

    public int StatusId { get; set; }

    public bool IsDeleted { get; set; }

    public int BoothId { get; set; }

    public int TotalPrice { get; set; }

    public int Commission { get; set; }

    public virtual Booth Booth { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual Status Status { get; set; } = null!;

    public virtual AppUser User { get; set; } = null!;
}
