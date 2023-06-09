namespace App.EndPoints.Home_RepaireUI.Areas.Seller.Models.Booth
{
    public class BoothViewModel
    {
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public string Description { get; set; }
        public int cityId { get; set; }
        public int TotalSales { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
