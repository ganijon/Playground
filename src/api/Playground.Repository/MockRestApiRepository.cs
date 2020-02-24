using Playground.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Playground.Repository
{
    public class MockRestApiRepository : IRepository
    {
        public IQueryable<Author> Authors => mockAuthors.AsQueryable();

        public IQueryable<Book> Books => mockAuthors.SelectMany(x => x.Books).AsQueryable();

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

            bookAuthor.Books.Add(book);
            return book;
        }

        #region Mock Data
        private List<Author> mockAuthors = new List<Author>
        {
            new Author {
                Name = "James Joyce",
                Id = 1,
                Books  = new List<Book>
                {
                    new Book { Name = "Ulysses", Id = 1, AuthorId = 1, Genre = "Modernist novel", Published = true },
                    new Book { Name = "Dubliners", Id = 2, AuthorId = 1, Genre = "Short story", Published = true },
                }
            },

            new Author {
                Name = "Leo Tolstoy",
                Id = 2,
                Books  = new List<Book>
                {
                    new Book { Name = "War and Peace", Id = 3, AuthorId = 2, Genre = "Historical novel", Published = true },
                    new Book { Name = "Anna Karenina", Id = 4, AuthorId = 2, Genre = "Realist novel", Published = true },
                    new Book { Name = "The Cossacks", Id = 5, AuthorId = 2, Genre = "Fiction", Published = true },
                }
            },

             new Author {
                Name = "Fyodor Dostoyevsky",
                Id = 3,
                Books  = new List<Book>
                {
                    new Book { Name = "Crime and Punishment", Id = 6, AuthorId = 3, Genre = "Psychological fiction", Published = true },
                    new Book { Name = "The Gambler", Id = 7, AuthorId = 3, Genre = "Novel", Published = true },
                }
            }
        };
        #endregion
    }
}
