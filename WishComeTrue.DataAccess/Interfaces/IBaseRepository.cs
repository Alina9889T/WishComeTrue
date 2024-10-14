using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishComeTrue.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();
        T GetWishById(string id);
        Task Create(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}
