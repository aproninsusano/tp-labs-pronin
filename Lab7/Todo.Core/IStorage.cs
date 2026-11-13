using System.Collections.Generic;

namespace Todo.Core;

public interface IStorage
{
    void Save(IEnumerable<TaskItem> tasks);
    List<TaskItem> Load();
}