
namespace App.EndPoints.Home_RepaireUI.Areas.Admin.Models
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public string BuyerUserId { get; set; } = null!;
        public DateTime OrderCreatTime { get; set; }
        public string status { get; set; }
        public string BoothName { get; set; }
        public int TotalPrice { get; set; }

    }
}
