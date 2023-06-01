using System;
using System.Collections.Generic;

namespace temp_entity.Models;

public partial class CustomerAddress
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public bool IsMainAddress { get; set; }

    public string? CityRegionTitle { get; set; }

    public string? FullAddress { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
