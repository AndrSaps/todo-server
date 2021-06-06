using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToDo.DataLayer.Entityes
{
    public class TaskModel: BaseEntity
    {

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Text { get; set; }

        [Required]
        public bool Status { get; set; }

        public DateTime? Deadline { get; set; }

        public int? CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual CategoryModel Category { get; set; }
    }
}
