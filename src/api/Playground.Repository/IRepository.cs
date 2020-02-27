using Playground.Data;
using System;
using System.Linq;

namespace Playground.Repository
{
    public interface IRepository
    {
        IQueryable<Author> Authors { get; }
        IQueryable<Publisher> Publishers { get; }
        IQueryable<Book> Books { get; }

        Author Add(Author obj);
        Book Add(Book obj);
    }
}
