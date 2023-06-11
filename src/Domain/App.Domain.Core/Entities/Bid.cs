using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;
public partial class Bid
{
    public int Id { get; set; }

    public int SuggestedPrice { get; set; }

    public int UserId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsCreated { get; set; }

    public int AuctionId { get; set; }

    public virtual Auction Auction { get; set; } = null!;
}
