using System;
using System.Collections.Generic;
using System.Text;
using ToDo.DataLayer.Entityes;
using ToDo.Repository;
using ToDo.Services.Interfaces;

namespace ToDo.Services.EFImplementations
{
    public class TaskService:ITaskService
    {
        private readonly IRepository<TaskModel> taskRepository;

        public TaskService(IRepository<TaskModel> taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public TaskModel GetTask(int TaskID)
        {
            if (TaskID != 0)
            {
                return taskRepository.GetItemById(TaskID);
            }
            else return null;
        }

        public void AddTask(TaskModel NewTask)
        {
            taskRepository.AddItem(NewTask);
        }

        public void DeleteTask(int TaskToDelete)
        {
            TaskModel TempTask = taskRepository.GetItemById(TaskToDelete);
            taskRepository.DeleteItem(TempTask);
        }

        public IEnumerable<TaskModel> GetTasks()
        {
            return taskRepository.GetAll();
        }

        public void UpdateTask(TaskModel NewTask)
        {
            taskRepository.UpdateItem(NewTask);
        }
    }
}
