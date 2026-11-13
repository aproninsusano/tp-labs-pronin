namespace Todo.Core;

public class TaskItem
{
    public int Id { get; }
    public string Title { get; set; }
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; }

    public TaskItem(int id, string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Название задачи не может быть пустым", nameof(title));
        Id = id;
        Title = title;
        IsDone = false;
        CreatedAt = DateTime.Now;
    }
}