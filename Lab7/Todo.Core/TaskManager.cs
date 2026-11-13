using System;
using System.Collections.Generic;
using System.Linq;

namespace Todo.Core;

public class TaskManager
{
    private readonly List<TaskItem> _tasks = new();
    private int _nextId = 1;

    public IReadOnlyList<TaskItem> Tasks => _tasks;

    public TaskItem Add(string title)
    {
        var task = new TaskItem(_nextId++, title);
        _tasks.Add(task);
        return task;
    }

    public bool MarkDone(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return false;
        task.IsDone = true;
        return true;
    }

    public bool Delete(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return false;
        _tasks.Remove(task);
        return true;
    }

    public int Count(bool? isDone = null)
    {
        if (isDone == null) return _tasks.Count;
        return _tasks.Count(t => t.IsDone == isDone);
    }
}