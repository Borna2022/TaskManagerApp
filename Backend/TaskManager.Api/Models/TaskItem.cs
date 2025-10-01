namespace TaskManager.Api.Models
{
    // ✅ موجودیت وظیفه
    public class TaskItem
    {
        public int Id { get; set; }                 // کلید اصلی
        public string Title { get; set; } = "";     // عنوان وظیفه
        public string? Description { get; set; }    // توضیحات
        public bool IsCompleted { get; set; } = false; // وضعیت انجام
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // کلید خارجی به User
        public int UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
