using Playground.Data;
using Playground.Graph.Schema.Types;
using Playground.Graph.Services;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace Playground.Graph.Schema.Subscriptions
{
    public class TheSubscription : ObjectGraphType<object>
    {
        public TheSubscription(IAuthorService authorService, IBookService bookService)
        {
            Name = "Subscription";

            AddField(new EventStreamFieldType
            {
                Name = "authorAdded",
                Type = typeof(AuthorType),
                Resolver = new FuncFieldResolver<Author>((context) => context.Source as Author),
                Subscriber = new EventStreamResolver<Author>((context) => authorService.AuthorAdded())
            });

            AddField(new EventStreamFieldType
            {
                Name = "bookAdded",
                Type = typeof(BookType),
                Resolver = new FuncFieldResolver<Book>((context) => context.Source as Book),
                Subscriber = new EventStreamResolver<Book>((context) => bookService.BookAdded())
            });
        }
    }
}
