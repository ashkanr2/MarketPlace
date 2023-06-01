using System;
using System.Collections.Generic;

namespace temp_entity.Models;

public partial class Bid
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ExpertId { get; set; }

    public int StatusId { get; set; }

    public int ExpertSuggestedPrice { get; set; }

    public string ExpertSuggestionComment { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual Expert Expert { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual BidStatus Status { get; set; } = null!;
}
