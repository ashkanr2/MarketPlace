namespace App.EndPoints.Home_RepaireUI.Areas.Admin.Models.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public int BoothId { get; set; }
        public string BoothName { get; set; }
        public int OrderId { get; set; }
        public bool IsCreated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
