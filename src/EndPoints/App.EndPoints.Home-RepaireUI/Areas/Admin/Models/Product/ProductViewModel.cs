using App.Domain.Core.DtoModels;
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

        public virtual ICollection<ProductImageDto> ProductImages { get; set; } = new List<ProductImageDto>();
    }
}
