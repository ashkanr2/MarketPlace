using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class SellerInformation
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string NationalCode { get; set; } = null!;

    public int ZipCode { get; set; }


    public int? CountOfSell { get; set; }

    public int? SellerMedalId { get; set; }

    public int CityId { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual SellerMedal? SellerMedal { get; set; }

    public virtual AppUser User { get; set; } = null!;
}
