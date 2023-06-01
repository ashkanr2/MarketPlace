namespace App.EndPoints.Home_RepaireUI.Areas.Admin.Models.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public int UnitPrice { get; set; }

        public int AllProductId { get; set; }

        public DateTime? AddTime { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsAccepted { get; set; }

        //public virtual AllProduct AllProduct { get; set; } = null!;

        //public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        //public virtual ICollection<ProductBid> ProductBids { get; set; } = new List<ProductBid>();

        //public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    }
}
