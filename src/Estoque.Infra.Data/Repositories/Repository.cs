using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces;
using Estoque.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;


namespace Estoque.Infra.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected SQLContext SqlContext { get; }
        protected DbSet<T> DbSet { get; }
        public Repository(SQLContext sqlContext)
        {
            SqlContext = sqlContext;
            DbSet = SqlContext.Set<T>();
        }
        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(long id)
        {
            var entity = GetById(id);
            DbSet.Remove(entity!);
        }

        public List<T> GetAll()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public PaginationData<T> GetAllPaginated(int page, int limit)
        {
            var total = DbSet.LongCount();

            var res = DbSet.AsNoTracking()
                       .Skip((page - 1) * limit)
                       .Take(limit)
                       .ToList();

            return new PaginationData<T>(res, page, limit, total);
        }

        public T? GetById(long id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<T> Search(Expression<Func<T, bool>> expression)
        {
            return DbSet.AsNoTracking()
                       .Where(expression)
                       .ToList();
        }

        public PaginationData<T> SearchPaginated(Expression<Func<T, bool>> expression, int page, int limit)
        {
            var total = DbSet.LongCount(expression);

            var res = DbSet.AsNoTracking()
                       .Where(expression)
                       .Skip((page - 1) * limit)
                       .Take(limit)
                       .ToList();

            return new PaginationData<T>(res, page, limit, total);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
    }
}
