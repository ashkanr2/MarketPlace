using App.Domain.Core.DtoModels;
namespace App.EndPoints.Home_RepaireUI.Areas.Admin.Models.User
{
    public class AppUserViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; } = null!;
        public DateTimeOffset CreatAt { get; set; }

        public bool IsDeleted { get; set; }

        public int? BuyerMedalId { get; set; }

        public string? CountOfBuy { get; set; }

        public int? UserProfileImageId { get; set; }

        public bool IsSeller { get; set; }

        public bool IsCreated { get; set; }

        public int Wallet { get; set; }


    }
}
