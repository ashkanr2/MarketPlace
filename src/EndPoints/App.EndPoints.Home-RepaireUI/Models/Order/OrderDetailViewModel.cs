using App.Domain.Core.DtoModels;
using App.EndPoints.Home_RepaireUI.Models.Product;
namespace App.EndPoints.Home_RepaireUI.Models.Order
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public DateTime OrderCreatTime { get; set; }
        public string status { get; set; }
        public string BoothName { get; set; }
        public int TotalPrice { get; set; }
        public int Commission { get; set; }
        public virtual ICollection<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
    }
}
