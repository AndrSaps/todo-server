using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.DataLayer.Entityes;

namespace ToDo.DataLayer
{
    public class TaskContext: DbContext
    {
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {

        }

    }

    public class EFDBContextFactory : IDesignTimeDbContextFactory<TaskContext>
    {
        public TaskContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaskContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TaskDataBase;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("ToDo.DataLayer"));

            return new TaskContext(optionsBuilder.Options);
        }
    }

}
