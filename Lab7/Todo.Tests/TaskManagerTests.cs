using Todo.Core;
using Xunit;

namespace Todo.Tests;

public class TaskManagerTests
{
    [Fact]
    public void Add_ValidTitle_CreatesTask()
    {
        var manager = new TaskManager();
        var task = manager.Add("Купить хлеб");
        Assert.Equal(1, manager.Count());
        Assert.Equal("Купить хлеб", task.Title);
    }

    [Fact]
    public void Add_EmptyTitle_ThrowsException()
    {
        var manager = new TaskManager();
        Assert.Throws<ArgumentException>(() => manager.Add(""));
    }

    [Fact]
    public void MarkDone_ExistingTask_ReturnsTrueAndChangesState()
    {
        var manager = new TaskManager();
        var task = manager.Add("Сдать лабу");
        bool result = manager.MarkDone(task.Id);
        Assert.True(result);
        Assert.True(task.IsDone);
    }

    [Fact]
    public void MarkDone_InvalidId_ReturnsFalse()
    {
        var manager = new TaskManager();
        Assert.False(manager.MarkDone(999));
    }

    [Fact]
    public void Delete_ExistingTask_RemovesIt()
    {
        var manager = new TaskManager();
        var task = manager.Add("Помыть посуду");
        manager.Delete(task.Id);
        Assert.Equal(0, manager.Count());
    }

    [Fact]
    public void Count_WithFilter_ReturnsCorrect()
    {
        var manager = new TaskManager();
        var t1 = manager.Add("Задача 1");
        manager.Add("Задача 2");
        manager.MarkDone(t1.Id);

        Assert.Equal(2, manager.Count());
        Assert.Equal(1, manager.Count(true));
        Assert.Equal(1, manager.Count(false)); 
    }

    [Fact]
    public void Id_IsIncremented()
    {
        var manager = new TaskManager();
        var t1 = manager.Add("1");
        var t2 = manager.Add("2");
        Assert.NotEqual(t1.Id, t2.Id);
        Assert.Equal(1, t1.Id);
        Assert.Equal(2, t2.Id);
    }

    [Fact]
    public void TasksCollection_IsReadOnly()
    {
        var manager = new TaskManager();
        manager.Add("Тест");
        Assert.IsAssignableFrom<IReadOnlyList<TaskItem>>(manager.Tasks);
    }
}