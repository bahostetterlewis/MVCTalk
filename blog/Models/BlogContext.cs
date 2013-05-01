using System.Data.Entity;
using blog.Models.Entities;
using blog.Models.Repositories;

namespace blog.Models
{
    public class BlogContext : DbContext, IUnitOfWork
    {
        #region DbSets

        public DbSet<Entry> Entries { get; set; }

        #endregion DbSets

        #region Implement IUnitOfWork Properties

        public IGenericRepository<Entry> EntryRepository
        {
            get { return _entryRepository ?? (_entryRepository = new GenericBlogRepository<Entry>(Entries, this)); }
        }

        #endregion Implement IUnitOfWork Properties

        #region Implement IUnitOfWork Functions

        public void Commit()
        {
            SaveChanges();
        }

        #endregion Implement IUnitOfWork Functions

        #region RepositoryFields

        private GenericBlogRepository<Entry> _entryRepository;

        #endregion RepositoryFields
    }
}