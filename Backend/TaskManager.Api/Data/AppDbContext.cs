using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Models;

namespace TaskManager.Api.Data
{
    // ✅ DbContext برای مدیریت ارتباط با دیتابیس
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<TaskItem> Tasks => Set<TaskItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // اسکیما پیش‌فرض
            modelBuilder.HasDefaultSchema("app");

            // User
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("Users");
                e.HasKey(x => x.Id);
                e.Property(x => x.Username).HasMaxLength(50).IsRequired();
                e.HasIndex(x => x.Username).IsUnique(); //  ایندکس برای بهینه‌سازی
                e.Property(x => x.PasswordHash).HasMaxLength(200).IsRequired();
                e.Property(x => x.Email).HasMaxLength(100);
            });

            // TaskItem
            modelBuilder.Entity<TaskItem>(e =>
            {
                e.ToTable("Tasks");
                e.HasKey(x => x.Id);
                e.Property(x => x.Title).HasMaxLength(200).IsRequired();
                e.HasOne(x => x.User)
                 .WithMany(u => u.Tasks)
                 .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
                e.HasIndex(x => x.UserId).HasDatabaseName("IX_Tasks_UserId");
            });
        }
    }
}
