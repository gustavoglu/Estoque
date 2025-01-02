using Estoque.Domain.Entities;
using Estoque.Domain.ViewModels;
using System.Linq.Expressions;

namespace Estoque.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        void Insert(T entity);
        void Update( T entity);
        void Delete(long id);
        T? GetById(long id);
        List<T> GetAll();
        PaginationData<T> GetAllPaginated(int page, int limit);
        PaginationData<T> SearchPaginated(Expression<Func<T, bool>> expression, int page, int limit);
        List<T> Search(Expression<Func<T, bool>> expression);
    }
}
