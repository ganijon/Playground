using Playground.Data;
using System.Collections.Generic;
using System.Linq;

namespace Playground.Repository
{
    public class MockRepository : IRepository
    {
        public IQueryable<Book> Books =>
            (
                from book in mockBooks
                join author in mockAuthors on book.AuthorId equals author.Id
                join publisher in mockPublishers on book.PublisherId equals publisher.Id
                select new Book
                {
                    Id = book.Id,
                    Name = book.Name,
                    Genre = book.Genre,
                    AuthorId = author.Id,
                    Author = author,
                    PublisherId = publisher.Id,
                    Publisher = publisher
                }
            )
            .AsQueryable();

        public IQueryable<Author> Authors =>
            (
                from author in mockAuthors
                join book in Books on author.Id equals book.AuthorId into books
                select new Author
                {
                    Id = author.Id,
                    Name = author.Name,
                    Books = books
                }
            )
            .AsQueryable();

        public IQueryable<Publisher> Publishers =>
            (
                from publisher in mockPublishers
                join book in Books on publisher.Id equals book.PublisherId into books
                select new Publisher
                {
                    Id = publisher.Id,
                    Name = publisher.Name,
                    Books = books
                }
            )
            .AsQueryable();


        public Author Add(Author author)
        {
            author.Id = Authors.Count() + 1;
            author.Books = new List<Book>();
            mockAuthors.Add(author);
            return author;
        }

        public Book Add(Book book)
        {
            var bookAuthor = Authors.FirstOrDefault(x => x.Id == book.AuthorId);

            if (bookAuthor == null)
                bookAuthor = Add(new Author { Name = "Unknown" });

            book.Id = bookAuthor.Books.Count() + 1;

            (bookAuthor.Books as List<Book>).Add(book);
            return book;
        }

        #region Mock Data
        private List<Author> mockAuthors = new List<Author>
        {
            new Author { Id = 1, Name = "James Joyce" },
            new Author { Id = 2, Name = "Leo Tolstoy" },
            new Author { Id = 3, Name = "Fyodor Dostoyevsky" },
            new Author { Id = 4, Name = "Vladimir Nabokov" }
        };

        private List<Publisher> mockPublishers = new List<Publisher>
        {
            new Publisher { Id = 1, Name = "McGraw-Hill" },
            new Publisher { Id = 2, Name = "Elliot Stock" },
            new Publisher { Id = 3, Name = "Elsevier" },
            new Publisher { Id = 4, Name = "Penguin Classics" },
            new Publisher { Id = 5, Name = "Atlantic Books" },
            new Publisher { Id = 6, Name = "Kensington Books" },
            new Publisher { Id = 7, Name = "Hackett Publishing Company" },
            new Publisher { Id = 8, Name = "Hawthorne Books" },
            new Publisher { Id = 9, Name = "O'Reilly Media" },
        };

        private List<Book> mockBooks = new List<Book>
        {
            new Book { Id = 1, Name = "Ulysses",                Genre = "Modernist novel",       AuthorId = 1, PublisherId = 1 },
            new Book { Id = 2, Name = "Dubliners",              Genre = "Short story",           AuthorId = 1, PublisherId = 2 },
            new Book { Id = 3, Name = "War and Peace",          Genre = "Historical novel",      AuthorId = 2, PublisherId = 3 },
            new Book { Id = 4, Name = "Anna Karenina",          Genre = "Realist novel",         AuthorId = 2, PublisherId = 3 },
            new Book { Id = 5, Name = "The Cossacks",           Genre = "Fiction",               AuthorId = 2, PublisherId = 4 },
            new Book { Id = 6, Name = "Crime and Punishment",   Genre = "Psychological fiction", AuthorId = 3, PublisherId = 5 },
            new Book { Id = 7, Name = "The Gambler",            Genre = "Novel",                 AuthorId = 3, PublisherId = 6 },
            new Book { Id = 8, Name = "The Devils",             Genre = "Novel",                 AuthorId = 3, PublisherId = 4 },
            new Book { Id = 9, Name = "Lolita",                 Genre = "Romance novel",         AuthorId = 4, PublisherId = 7 },
            new Book { Id = 10, Name = "Pale Fire",             Genre = "Novel, Fiction",        AuthorId = 4, PublisherId = 8 },
        };

        #endregion
    }
}
