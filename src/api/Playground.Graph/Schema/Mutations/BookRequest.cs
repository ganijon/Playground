using GraphQL.Types;

namespace Playground.Graph.Schema.Mutations
{
    public class BookRequest : InputObjectGraphType
    {
        public BookRequest()
        {
            Name = "BookRequest";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<IntGraphType>>("authorId");
        }
    }
}