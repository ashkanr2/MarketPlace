using System;
using System.Collections.Generic;

namespace temp_entity.Models;

public partial class Order
{
    public int Id { get; set; }

    public int StatusId { get; set; }

    public int CustomerId { get; set; }

    public int CustomerAddressId { get; set; }

    public int ServiceCategoryId { get; set; }

    public DateTime AvailabilityFrom { get; set; }

    public DateTime AvailabilityTo { get; set; }

    public DateTime? ExpertStartedWorkAt { get; set; }

    public DateTime? ExpertFinishedWorkAt { get; set; }

    public int? ScoreByExpertId { get; set; }

    public int? ScoreByCustomerId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? LastModifiedAt { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderService> OrderServices { get; set; } = new List<OrderService>();

    public virtual OrderStatue Status { get; set; } = null!;
}
