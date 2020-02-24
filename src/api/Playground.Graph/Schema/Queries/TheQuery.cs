using Playground.Graph.Schema.Types;
using Playground.Repository;
using GraphQL.Types;
using System.Linq;

namespace Playground.Graph.Schema.Queries
{
    public class TheQuery : ObjectGraphType<object>
    {
        public TheQuery(IRepository repository)
        {
            Name = "Query";

            // Expose author by id
            Field<AuthorType>("Author",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return repository.Authors.FirstOrDefault(x => x.Id == id);
                });

            // Expose a book by id
            Field<BookType>("Book",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return repository.Books.FirstOrDefault(x => x.Id == id);
                });


            // Expose all authors filtered name substring
            Field<ListGraphType<AuthorType>>("Authors",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "name" }),
                resolve: context =>
                {
                    var searchString = context.GetArgument<string>("name");
                    var list = repository.Authors.ToList();

                    return (searchString != default)
                        ? repository.Authors.Where(x => x.Name.ToLower().Contains(searchString.ToLower()))
                        : repository.Authors;
                });

            // Expose all books filtered name substring
            Field<ListGraphType<BookType>>("Books",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "name" }),
                resolve: context =>
                {
                    var searchString = context.GetArgument<string>("name");
                    return (searchString != default)
                        ? repository.Books.Where(x => x.Name.ToLower().Contains(searchString.ToLower()))
                        : repository.Books;
                });


        }
    }
}
