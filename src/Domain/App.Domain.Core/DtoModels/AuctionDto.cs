using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels
{
    public class AuctionDto
    {
        public int Id { get; set; }

        public int BidId { get; set; }

        public int ProductId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int WinnerId { get; set; }

        public virtual BidDto Bid { get; set; } = null!;

        public virtual ProductDto Product { get; set; } = null!;
    }
}
