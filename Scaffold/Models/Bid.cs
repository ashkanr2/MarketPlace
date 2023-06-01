using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class Bid
{
    public int Id { get; set; }

    public int SuggestedPrice { get; set; }

    public int UserId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsCreated { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();
}
