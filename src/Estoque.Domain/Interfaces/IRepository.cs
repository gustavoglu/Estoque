using Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        void Insert(T entity);
        void Update( T entity);
        void Delete(long id);
        T? GetById(long id);
        List<T> GetAll();
        List<T> GetAllPaginated(int page, int limit);
        List<T> SearchPaginated(Expression<Func<T, bool>> expression, int page, int limit);
        List<T> Search(Expression<Func<T, bool>> expression);
    }
}
