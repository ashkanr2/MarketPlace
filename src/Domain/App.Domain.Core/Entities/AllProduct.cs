using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class AllProduct
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsCreated { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
