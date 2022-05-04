using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<IList<T>> FindAll();
        Task<T> FindById(int id);
        Task<T> Add(T type);
        Task Update(T type);
        Task Delete(T type);

    }
}
