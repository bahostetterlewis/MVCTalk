using System.Linq;

namespace blog.Models.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> All { get; }
        T Find(int id);
        void InsertOrUpdate(ref T entity, int id);
        void Delete(int id);
    }
}