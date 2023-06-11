using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class Province
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
