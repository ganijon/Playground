using GraphQL.Types;

namespace Playground.Graph.Schema.Mutations
{
    public class AuthorRequest : InputObjectGraphType
    {
        public AuthorRequest()
        {
            Name = "AuthorRequest";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}