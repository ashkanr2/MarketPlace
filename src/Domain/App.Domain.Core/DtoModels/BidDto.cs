using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class BidDto
    {
        public int Id { get; set; }

        public int SuggestedPrice { get; set; }

        public int UserId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsCreated { get; set; }

        public int AuctionId { get; set; }

        public virtual AuctionDto Auction { get; set; } = null!;
    }
}
