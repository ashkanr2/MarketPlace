using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class AppUser : IdentityUser<int>
{
    public string Address { get; set; } = null!;
    public DateTimeOffset CreatAt { get; set; }

    public bool IsDeleted { get; set; }

    public int? BuyerMedalId { get; set; }

    public string? CountOfBuy { get; set; }

    public int? UserProfileImageId { get; set; }

    public bool IsSeller { get; set; }

    public bool IsCreated { get; set; }

    public int Wallet { get; set; }

    public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();

    public virtual BuyerMedal? BuyerMedal { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<SellerInformation> SellerInformations { get; set; } = new List<SellerInformation>();

    public virtual Image? UserProfileImage { get; set; }
}
