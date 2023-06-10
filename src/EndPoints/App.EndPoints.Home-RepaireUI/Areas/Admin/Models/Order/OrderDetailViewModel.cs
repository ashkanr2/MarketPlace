namespace App.EndPoints.Home_RepaireUI.Areas.Admin.Models.Order
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderCreatTime { get; set; }
        public string status { get; set; }
        public string BoothName { get; set; }
        public int TotalPrice { get; set; }
        public string UserName { get; set; } = null!;
        public int Commission { get; set; }
    }
}
