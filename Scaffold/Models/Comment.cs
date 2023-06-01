using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Comment1 { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public int BoothId { get; set; }

    public int OrderId { get; set; }

    public bool IsAccepted { get; set; }

    public virtual Booth Booth { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual AppUser User { get; set; } = null!;
}
