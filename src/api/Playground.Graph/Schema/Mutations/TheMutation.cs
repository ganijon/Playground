using Playground.Data;
using Playground.Graph.Schema.Types;
using Playground.Graph.Services;
using GraphQL.Types;

namespace Playground.Graph.Schema.Mutations
{
    public class TheMutation : ObjectGraphType<object>
    {
        public TheMutation(IAuthorService authorService, IBookService bookService)
        {
            Name = "Mutation";

            Field<AuthorType>("addAuthor",
             arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AuthorRequest>> { Name = "author" }),
             resolve: context =>
             {
                 var req = context.GetArgument<AuthorRequest>("author");

                 var author = new Author { Name = req.Name };

                 return authorService.Create(author);
             });

            Field<BookType>("addBook",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<BookRequest>> { Name = "book" }),
            resolve: context =>
            {
                var book = context.GetArgument<Book>("book");

                return bookService.Create(book);
            });
        }
    }
}

