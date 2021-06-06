using System;
using System.Collections.Generic;
using System.Text;
using ToDo.DataLayer.Entityes;

namespace ToDo.Services.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<TaskModel> GetTasks();

        TaskModel GetTask(int TaskID);

        void AddTask(TaskModel NewTask);

        void UpdateTask(TaskModel NewTask);

        void DeleteTask(int TaskToDelete);
    }
}
