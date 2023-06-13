using App.Domain.Core.DtoModels;
namespace App.EndPoints.Home_RepaireUI.Areas.Seller.Models.Auction
{
    public class AuctionViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int WinnerId { get; set; }

        public virtual ICollection<BidDto> Bids { get; set; } = new List<BidDto>();

        public virtual ProductDto Product { get; set; } = null!;
    }
}
