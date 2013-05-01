using System.Data.Entity;
using blog.Models;
using blog.Models.Entities;

namespace blog.Models
{
    public class BlogContext : DbContext
    {
        #region DbSets
        public DbSet<Entry> Entries { get; set; }
        #endregion
    }
}