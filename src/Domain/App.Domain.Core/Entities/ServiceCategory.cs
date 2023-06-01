using System;
using System.Collections.Generic;

namespace temp_entity.Models;

public partial class ServiceCategory
{
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
