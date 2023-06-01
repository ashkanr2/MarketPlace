using System;
using System.Collections.Generic;

namespace temp_entity.Models;

public partial class OrderService
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ServiceId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
