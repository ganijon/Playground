using Playground.Data;
using System.Collections.Generic;
using System.Linq;

namespace Playground.Repository
{
    public class MockGraphQLApiRepository : IRepository
    {
        public IQueryable<Author> Authors => mockAuthors
            .SelectMany(a => a.Books.Select(b => b.Author = a))
            .Distinct()
            .AsQueryable();

        public IQueryable<Book> Books => Authors
            .SelectMany(a => a.Books)
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
            },

             new Author {
                Name = "Vladimir Nabokov",
                Id = 4,
                Books  = new List<Book>
                {
                    new Book { Name = "Lolita", Id = 8, AuthorId = 4, Genre = "Novel, Fiction, Romance novel, Tragicomedy", Published = true },
                    new Book { Name = "Pale Fire", Id = 9, AuthorId = 4, Genre = "Novel, Fiction, Experimental literature", Published = true },
                }
            },

        };
        #endregion
    }
}
