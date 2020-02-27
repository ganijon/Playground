using Playground.Data;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.Graph.Schema.Types
{
    public class PublisherType : ObjectGraphType<Publisher>
    {
        public PublisherType()
        {
            Name = "Publisher";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("Publisher's ID.");
            Field(x => x.Name).Description("The name of the Publisher");
            Field(x => x.Books, type: typeof(ListGraphType<BookType>)).Description("Publisher's books");
        }
    }
}
