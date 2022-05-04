using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Data.Interfaces
{
    public interface IDAO<T>
    {
        Task Create(T t);
        Task<T> Read(int id);
        Task<List<T>> ReadAll();
        Task Update(T newObject);
        Task Delete(T objectDelete);
    }
}
