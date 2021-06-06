using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetItemById(int ItemId);

        void AddItem(T NewItem);

        void UpdateItem(T NewItem);

        void DeleteItem(T ItemToDelete);
    }
}
