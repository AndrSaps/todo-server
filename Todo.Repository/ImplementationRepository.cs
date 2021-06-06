using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.DataLayer;
using ToDo.DataLayer.Entityes;

namespace ToDo.Repository
{
    public class ImplementationRepository<T> : IRepository<T> where T: BaseEntity
    {
        private TaskContext context;
        private DbSet<T> entityes;

        public ImplementationRepository(TaskContext _context)
        {
            context = _context;
            entityes = _context.Set<T>();
        }

        public void AddItem(T NewItem)
        {
            if (NewItem == null)
            {
                throw new ArgumentNullException();
            }
            entityes.Add(NewItem);
            context.SaveChanges();
        }

        public void DeleteItem(T ItemToDelete)
        {
            if (ItemToDelete == null)
            {
                throw new ArgumentNullException();
            }
            context.Remove(ItemToDelete);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return entityes.AsEnumerable();
        }

        public T GetItemById(int ItemId)
        {
            return entityes.SingleOrDefault(x => x.ID == ItemId);
        }

        public void UpdateItem(T NewItem)
        {
            context.Update(NewItem);
            //context.Entry(NewItem).State=EntityState.Modified;
            context.SaveChanges();
        }
    }
}
