using System;
using System.Collections.Generic;

namespace temp_entity.Models;

public partial class Customer
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? GenderId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime? Birthdate { get; set; }

    public int? CityId { get; set; }

    public string MobileNumber { get; set; } = null!;

    public string BackupMobileNumber { get; set; } = null!;

    public int? ScoreAvg { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? DeletedBy { get; set; }

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
