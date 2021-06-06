using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.API.Models
{
    public class TaskView
    {
        public int ID;

        public string Text { get; set; }

        public bool Status { get; set; }

        public DateTime? Deadline { get; set; }

        public int? CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Color { get; set; }
    }
}
