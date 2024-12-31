using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Estoque.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
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

        public List<T> GetAllPaginated(int page, int limit)
        {
            return DbSet.AsNoTracking()
                        .Skip((page - 1) * limit)
                        .Take(limit)
                        .ToList();
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

        public List<T> SearchPaginated(Expression<Func<T, bool>> expression, int page, int limit)
        {
            return DbSet.AsNoTracking()
                       .Where(expression)
                       .Skip((page - 1) * limit)
                       .Take(limit)
                       .ToList();
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
    }
}
