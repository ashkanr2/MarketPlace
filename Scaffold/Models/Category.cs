using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int MotherCategoryId { get; set; }

    public virtual ICollection<AllProduct> AllProducts { get; set; } = new List<AllProduct>();

    public virtual MothersCategory MotherCategory { get; set; } = null!;
}
