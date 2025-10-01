namespace TaskManager.Api.Dtos
{
    public class TaskUpdateDto
    {
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
