using Playground.Data;
using Playground.Graph.Schema.Types;
using Playground.Repository;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Playground.Graph.Schema.Queries
{
    public class TheQuery : ObjectGraphType<object>
    {
        public TheQuery(IRepository repository)
        {
            Name = "Query";

            // Expose all authors
            Field<ListGraphType<AuthorType>>("Authors", resolve: context => { return repository.Authors; });

            // Expose all authors
            Field<ListGraphType<BookType>>("Books", resolve: context => { return repository.Books; });

            // Expose an author
            Field<AuthorType>("Author",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return repository.Authors.FirstOrDefault(x => x.Id == id);
                });


            // Expose a book
            Field<BookType>("Book",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return repository.Books.FirstOrDefault(x => x.Id == id);
                });
        }
    }
}
