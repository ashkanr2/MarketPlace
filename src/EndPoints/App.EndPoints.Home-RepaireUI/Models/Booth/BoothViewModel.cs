namespace App.EndPoints.Home_RepaireUI.Models.Booth
{
    public class BoothViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int OwnerUserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Description { get; set; } = null!;

        public int TotalSalesNumber { get; set; }

        public int? BoothImageId { get; set; }

        public bool IsDeleted { get; set; }

        public int CityId { get; set; }

        public bool IsCreated { get; set; }

    }
}
