using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Image
{
    public int Id { get; set; }

    public string Path { get; set; } = null!;

    public bool Isdeleted { get; set; }

    public bool IsProfileImage { get; set; }

    public bool IsAccepted { get; set; }

    public virtual ICollection<AspUser> AspUsers { get; set; } = new List<AspUser>();

    public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
}
