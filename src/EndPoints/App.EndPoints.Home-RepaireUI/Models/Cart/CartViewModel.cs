using App.Domain.Core.DtoModels;
using App.EndPoints.Home_RepaireUI.Models.Product;

namespace App.EndPoints.Home_RepaireUI.Models.Cart
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BoothId { get; set; }
        public DateTime CreateTime { get; set; }
        public CartProductDto CartProduct { get; set; }
        public virtual ICollection<ProductViewModel> CartProducts { get; set; } = new List<ProductViewModel>();

    }
}
