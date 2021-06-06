using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToDo.DataLayer.Entityes
{
    public class CategoryModel: BaseEntity
    {

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Color { get; set; }
    }
}
