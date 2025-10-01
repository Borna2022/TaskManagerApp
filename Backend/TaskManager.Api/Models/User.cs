namespace TaskManager.Api.Models
{
    // ✅ موجودیت کاربر
    public class User
    {
        public int Id { get; set; }                 // کلید اصلی
        public string Username { get; set; } = "";  // نام کاربری
        public string PasswordHash { get; set; } = ""; // رمز هش‌شده
        public string? Email { get; set; }          // ایمیل اختیاری
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // ارتباط یک به چند با Task
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
