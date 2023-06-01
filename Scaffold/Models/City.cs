using System;
using System.Collections.Generic;

namespace Scaffold.Models;

public partial class City
{
    public int Id { get; set; }

    public int ProvincesId { get; set; }

    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();

    public virtual Province Provinces { get; set; } = null!;

    public virtual ICollection<SellerInformation> SellerInformations { get; set; } = new List<SellerInformation>();
}
