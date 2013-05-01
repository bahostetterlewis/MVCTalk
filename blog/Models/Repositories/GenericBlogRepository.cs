using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using blog.Models.Entities;

namespace blog.Models.Repositories
{
    public class GenericBlogRepository<T> : IGenericRepository<T> where T : IEntity
    {
        private readonly DbSet<T> set;
        private readonly DbContext context;

        public GenericBlogRepository(DbSet<T> set, DbContext context)
        {
            this.set = set;
            this.context = context;
        }

        #region Implementing IGenericRepository
        public IQueryable<T> All
        {
            get { return set; }
        }

        public T Find(int id)
        {
            return set.Find(id);
        }

        public void InsertOrUpdate(ref T entity, int id)
        {
            if (id == default(int))
            {
                entity.ModifiedOn = entity.CreatedOn = DateTime.UtcNow;
                set.Add(entity);
            }
            else
            {
                entity.ModifiedOn = DateTime.UtcNow;
                context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var entity = set.Find(id);
            set.Remove(entity);
        }
        #endregion
    }
}