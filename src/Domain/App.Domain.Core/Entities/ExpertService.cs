using System;
using System.Collections.Generic;

namespace temp_entity.Models;

public partial class ExpertService
{
    public int Id { get; set; }

    public int ExpertId { get; set; }

    public int ServiceId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual Expert Expert { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
