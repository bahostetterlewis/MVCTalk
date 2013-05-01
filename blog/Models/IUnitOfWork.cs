using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blog.Models.Entities;
using blog.Models.Repositories;

namespace blog.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Entry> EntryRepository { get; }

        void Commit();
    }
}
