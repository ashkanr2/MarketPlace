using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class MothersCategory
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
