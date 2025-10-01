using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManager.Api.Data;
using TaskManager.Api.Dtos;
using TaskManager.Api.Models;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // همه‌ی اکشن‌ها نیاز به لاگین دارن
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        // گرفتن UserId از JWT
        private int GetUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var userId = GetUserId();
            var tasks = _context.Tasks.Where(t => t.UserId == userId).ToList();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            var userId = GetUserId();
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id && t.UserId == userId);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskCreateDto dto)
        {
            var userId = GetUserId();
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                UserId = userId,
                IsCompleted = dto.IsCompleted   //  مقدار از کلاینت گرفته می‌شود
            };
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Ok(task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskUpdateDto dto)
        {
            var userId = GetUserId();
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id && t.UserId == userId);
            if (task == null) return NotFound();

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.IsCompleted = dto.IsCompleted;

            _context.SaveChanges();
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var userId = GetUserId();
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id && t.UserId == userId);
            if (task == null) return NotFound();

            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return Ok(new { message = "Task deleted successfully" });
        }
    }
}
