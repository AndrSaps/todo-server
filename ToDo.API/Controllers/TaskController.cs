using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Models;
using ToDo.DataLayer.Entityes;
using ToDo.Services.Interfaces;

namespace ToDo.API.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ICategoryService categotyService;
        private readonly ITaskService taskService;

        public TaskController(ICategoryService categotyService, ITaskService taskService)
        {
            this.categotyService = categotyService;
            this.taskService = taskService;
        }


        //Add task
        [HttpGet]
        public IEnumerable<TaskView> GetTasks()
        {
            List<TaskView> tasks = new List<TaskView>();
            this.taskService.GetTasks().ToList().ForEach(x =>
            {
                CategoryModel TempCategory = null;
                if (x.CategoryID != null)
                {
                    TempCategory = categotyService.GetCategory(x.CategoryID ?? 0);
                }

                TaskView TempTask = new TaskView
                {
                    ID = x.ID,
                    Text = x.Text,
                    Status = x.Status,
                    Deadline = x.Deadline,
                    CategoryID = x.CategoryID,
                    CategoryName = TempCategory == null ? "" : TempCategory.Name,
                    Color = TempCategory == null ? "" : TempCategory.Color
                };
                tasks.Add(TempTask);

            });
            return tasks;
        }

        [HttpPost]
        public IActionResult AddTask([FromBody] TaskModel NewTask)
        {

            if (ModelState.IsValid)
            {
                taskService.AddTask(NewTask);
                return Ok(NewTask);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{TaskId}")]
        public IActionResult DeleteTask(int TaskId)
        {
            taskService.DeleteTask(TaskId);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateTask([FromBody] TaskModel NewTask)
        {

            if (NewTask.ID == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                taskService.UpdateTask(NewTask);
                return Ok(NewTask);
            }
            return BadRequest(ModelState);
        }

    }
}